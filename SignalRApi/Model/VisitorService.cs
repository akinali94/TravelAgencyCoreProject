

using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;

namespace SignalRApi.Model
{
    public class VisitorService
    {
        private readonly ContextApi _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(ContextApi context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }


        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetVisitorChartList());
        }

        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select date,[1],[2],[3],[4],[5] from (select[City],CityVisitCount,Cast([VisitDate] as Date) as date from Visitors) as visitTable Pivot (Sum(CityVisitCount) For City in([1],[2],[3],[4],[5])) as pivottable order by date asc";

                /*"SELECT VisitDate, [1] AS City1, [2] AS City2, [3] AS City3, [4] AS City4, [5] AS City5 FROM (SELECT [City], CityVisitCount, Cast([VisitDate] as VisitDate From Visitos) AS SourceTable PIVOT (SUM(CityVisitCount) FOR City IN ([1], [2], [3], [4], [5])) AS PivotTable ORDER BY VisitDate;";*/

                /*"SELECT VisitDate, [1] AS City1, [2] AS City2, [3] AS City3, [4] AS City4, [5] AS City5 FROM (SELECT VisitDate AS Date, City, CityVisitCount FROM Visitors) AS SourceTable PIVOT (SUM(CityVisitCount) FOR City IN ([1], [2], [3], [4], [5])) AS PivotTable ORDER BY VisitDate;"*/

                /*POSTGRESQL -> "Select * From crosstab ( 'Select VisitDate,City,CityVisitCount From Visitors Order By 1, 2') As ct(VisitDate date,City1 int, City2 int, City3 int, City4 int, City5 int);"*/
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                visitorChart.Counts.Add(0);
                            }
                            else
                            {
                                visitorChart.Counts.Add(reader.GetInt32(x));
                            }
                            
                        });
                        visitorCharts.Add(visitorChart);
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;
            }
        }
    }
}

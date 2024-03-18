using DBDatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reports;
using Microsoft.AspNetCore.Authorization;
using Tables;
using Microsoft.Data.SqlClient;

namespace Prueba_técnica.Pages
{
    public class ReportModel : PageModel
    {
        private readonly DatabaseContext _context;
        public IList<VentasPorEmpleado> VentasPorEmpleado { get; set; }
        public IList<SalesReport> SalesReport { get; set; }

        public IList<Employee>  Employees { get; set; }
        public ReportModel(DatabaseContext context)
        {
            _context = context;
            VentasPorEmpleado = new List<VentasPorEmpleado>();
            SalesReport = new List<SalesReport>();
            Employees = new List<Employee>();
        }

        public async Task OnGetAsync(int? year, int? start_date, int? end_date, string? employee_id)
        {
            //Reporte de Ventas por Empleado
            var yearParameter = year.HasValue ? new SqlParameter("@Year", year) : new SqlParameter("@Year", DBNull.Value);
            VentasPorEmpleado = await _context.VentasPorEmpleados.FromSqlRaw("EXEC GetSalesByEmployeePerYear @Year", yearParameter).ToListAsync();

            //Reporte de Ventas
            Employees = await _context.Employees.ToListAsync();
            var startDateParameter = start_date.HasValue ? new SqlParameter("@StartDate", start_date.Value.ToString("yyyy-MM-dd")) : new SqlParameter("@StartDate", DBNull.Value);
            var endDateParameter = end_date.HasValue ? new SqlParameter("@EndDate", end_date.Value.ToString("yyyy-MM-dd")) : new SqlParameter("@EndDate", DBNull.Value);
            var idEmployeeParameter = !string.IsNullOrEmpty(employee_id) ? new SqlParameter("@EmployeeID", employee_id) : new SqlParameter("@EmployeeID", DBNull.Value);

            SalesReport = await _context.salesReports.FromSqlRaw("EXEC GetSalesReportWithParameters @StartDate, @EndDate, @EmployeeID", startDateParameter, endDateParameter, idEmployeeParameter).ToListAsync();
            //SalesReport = await _context.salesReports.FromSqlRaw("EXEC GetSalesReportWithParameters").ToListAsync();
        }
    }
}

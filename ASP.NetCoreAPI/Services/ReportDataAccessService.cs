using ASP.NetCoreAPI.Models;
using ASP.NetCoreAPI.Services.Interfaces;
using System.Collections.Concurrent;

namespace ASP.NetCoreAPI.Services
{
    public class ReportDataAccessService : IReportsDataAccess
    {
        private readonly ConcurrentDictionary<Guid, Document> _reports;

        public ReportDataAccessService()
        {
            _reports = new ConcurrentDictionary<Guid, Document>();
        }

        private readonly object _lock_object = new object();


        //public Task<CreateReportResponse> CreateReportAsync(CreateReportRequest request)
        //{
        //    lock (_lock_object)
        //    {
        //        if (this._reports.ContainsKey(request.Document.ReportId))
        //        {
        //            return Task.FromResult(CreateReportResponse.Failure("Object with same Id already exists!"));

        //        }

        //        var sameJobNameExists = this._reports
        //            .Any(x => string.Equals(x.Value.JobName, request.Document.JobName));

        //        if (sameJobNameExists)
        //        {
        //            return Task.FromResult(CreateReportResponse.Failure("Object with same Job Name already exists!"));
        //        }

        //        var addResult = _reports.TryAdd(request.Document.ReportId, request.Document);

        //        if (addResult == false)
        //            throw new InvalidOperationException($"Fatal error add new report with id {request.Document.ReportId}");

        //    }

        //    return Task.FromResult(CreateReportResponse.Ok);
        //}

        //public Task<DeleteReportResponse> DeleteReportAsync(DeleteReportRequest request)
        //{
        //    if (_reports.TryRemove(request.ReportId, out var deletedReport))
        //    {
        //        return Task.FromResult(DeleteReportResponse.Ok);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException($"Fatal error delete report with id {request.ReportId}");
        //    }
        //}

        //public Task<GetReportsResponse> GetReportsAsync(GetReportsRequest request)
        //{
        //    var response = new GetReportsResponse()
        //    {
        //        Reports = this._reports.Values.ToList()
        //    };
        //    return Task.FromResult(response);
        //}

        //public Task<List<ReportType>> GetReportTypesAsync()
        //{
        //    // mock reading from db
        //    return Task.FromResult(new List<ReportType>()
        //    {
        //        new(1, "Move and stop"),
        //        new(2, "Messages from object"),
        //    });

        //}

        //public Task<List<MonitoringObject>> GetMonitoringObjectsAsync()
        //{
        //    // mock reading from db
        //    return Task.FromResult(new List<MonitoringObject>()
        //    {
        //        new(1, "o001oa178"),
        //        new(2, "o002oo47"),
        //        new(3, "a100aa777"),
        //    });
        //}

        //public Task<List<ReportPeriodicityDefine>> GetReportPeriodicityDefinesAsync()
        //{
        //    // mock reading from db
        //    return Task.FromResult(new List<ReportPeriodicityDefine>()
        //    {
        //        new(1, "Once a day"),
        //        new(2, "Once a week"),
        //        new(3, "Once a month"),
        //    });
        //}

        //public Task<BuildingParametersDefine> GetBuildingParametersDefineAsync(int reportTypeCode)
        //{
        //    // mock reading from db
        //    var response = reportTypeCode == 1
        //        ? new BuildingParametersDefine()
        //        {
        //            IsAllowMultiply = false,
        //            BuildingParameters = new List<BuildingParameter>()
        //            {
        //                new(1, "Day"),
        //                new(2, "Month"),
        //                new(3, "Year"),
        //            }
        //        }
        //        : reportTypeCode == 2 ? new BuildingParametersDefine()
        //        {
        //            IsAllowMultiply = true,
        //            BuildingParameters = new List<BuildingParameter>()
        //            {
        //                new(1, "Fuel"),
        //                new(2, "Ignition"),
        //                new(3, "Snock sensor"),
        //            }
        //        }
        //        : throw new ArgumentException("Type of report is not supported");

        //    return Task.FromResult(response);
        //}
    }
}

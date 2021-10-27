using System;
using System.Collections.Generic;
using System.Data;

namespace ConnectionTool
{
    public interface IConnection
    {
        string ConnectionString { get; }

        int ExecuteNonQuery(Command command);
        IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector);
        object ExecuteScalar(Command command);
        DataTable GetDataTable(Command command);
    }
}
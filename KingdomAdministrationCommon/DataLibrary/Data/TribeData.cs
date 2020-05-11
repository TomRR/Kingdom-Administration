using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    class TribeData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TribeData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        public async Task<int> CreateOrder(TribeModel tribe)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("TribeName", tribe.TribeName);
            p.Add("OrderDate", tribe.);
            p.Add("FoodId", order.FoodId);
            p.Add("Quantity", order.Quantity);
            p.Add("Total", order.Total);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spOrders_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateOrderName(int orderId, string orderName)
        {
            return _dataAccess.SaveData("dbo.spOrders_UpdateName",
                                        new
                                        {
                                            Id = orderId,
                                            OrderName = orderName
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteOrder(int orderId)
        {
            return _dataAccess.SaveData("dbo.spOrder_Delete",
                                        new
                                        {
                                            Id = orderId
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public async Task<OrderModel> GetOrderById(int orderId)
        {
            var recs = await _dataAccess.LoadData<OrderModel, dynamic>("dbo.spOrders_GetById",
                                                                       new
                                                                       {
                                                                           Id = orderId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}

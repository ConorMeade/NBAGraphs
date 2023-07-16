using NBAGraphs.Models;

namespace StockTracker
{
    public interface IDataService
    {
        public Task<List<StockPriceResponse>> GetIEXData(string symbol, DateTime startDate, DateTime endDate);

        //using rapid api nba stats
        public Task<List<GameLog>> GetPlayerGameLog(string id);
    }
}

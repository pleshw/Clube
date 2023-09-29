using Clube.Models.RPG;
using System.Data.Common;
using System.Numerics;
using static Clube.Models.RPG.RPGContext;

namespace Clube.Services;

public static class RPGPlayerService
{
    public static Guid AddPlayer( Player player )
    {
        using RPGContext dbPlayers = new();

        Guid updatedId = dbPlayers.Add( player ).Entity.Id;
        dbPlayers.SaveChanges();

        return updatedId;
    }

    //public static Guid RemovePlayer( Player player )
    //{
    //    using RPGContext dbPlayers = new();

    //    Guid updatedId = dbPlayers.Remove( player ).Entity.Id;
    //    dbPlayers.SaveChanges();

    //    return updatedId;
    //}

    public static Player? GetPlayerById( Guid playerId )
    {
        using RPGContext dbPlayers = new();

        return (from player in dbPlayers.Players
                where player.Id == playerId
                select player).FirstOrDefault();
    }

    //public static List<Player> GetPlayers()
    //{
    //    using RPGContext dbPlayers = new();

    //    return dbPlayers.Players.OrderBy(p => p.Name).ToList();
    //}

    public static Guid UpdatePlayer( Player player )
    {
        using RPGContext dbPlayers = new();
        Guid updatedId = dbPlayers.Players.Update( player ).Entity.Id;
        dbPlayers.SaveChanges();
        return updatedId;
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;
using Wonders.Database;

namespace Wonders
{
    public static class DatabaseProvider
    {
        public static List<Card> GetCards(int epoch)
        {
            var result = new List<Card>();
            for (int i = 0; i < 49; i++)
            {
                //result.Add(new MilitaryCard());
            }
            return result;
        }

        public static void ReadCards()
        {
            using (var db = new WondersContext())
            {
                db.MilitaryCards.Load();
                var militaryCards = db.MilitaryCards.Local.ToBindingList();

                foreach (var militaryCard in militaryCards)
                {
                        
                }
            }
        }

        public static void AddMilitaryCards(MilitaryCard dbCard)
        {
            using (var db = new WondersContext())
            {
                db.MilitaryCards.Add(dbCard);
                db.SaveChanges();
            }
        }

        public static void AddCards()
        {
            string strConnection = "Data Source=Database/WondersCards.db";
            string strCommand = File.ReadAllText("Database/insert_cards_script.sql");
            using (SQLiteConnection objConnection = new SQLiteConnection(strConnection))
            {
                using (SQLiteCommand objCommand = objConnection.CreateCommand())
                {
                    objConnection.Open();
                    objCommand.CommandText = strCommand;
                    objCommand.ExecuteNonQuery();
                    objConnection.Close();
                }
            }
            var sql_con = new SQLiteConnection("Data Source=c:\\Dev\\MYApp.sqlite;Version=3;New=False;Compress=True;");
            SQLiteCommand insertSql = new SQLiteCommand("INSERT INTO DbCards (Id, Text, UniqCardId, CardType, Epoch, MinPlayers, Wood, Stone, Gold, Brick, Papirus, Glass, CardBenefit, CoinsCost, ParentUniqCard) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
            //insertSql.Parameters.Add()
        }
    }
}

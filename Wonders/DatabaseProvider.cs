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
using Wonders.Enums;

namespace Wonders
{
    public static class DatabaseProvider
    {
        static string strConnection = "Data Source=Database/WondersCards.db";

        public static void AddCards()
        {
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
        }

        public static List<Card> ReadAllCards()
        {
            string strCommand = File.ReadAllText("Database/select_cards_script.sql");
            var result = new List<Card>();
            using (SQLiteConnection objConnection = new SQLiteConnection(strConnection))
            {
                objConnection.Open();
                using (SQLiteCommand command = new SQLiteCommand(strCommand, objConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Card card;
                            var type = (CardType) reader.GetInt32(3);
                            switch (type)
                            {
                                case CardType.MilitaryCard:
                                    card = new MilitaryCard();
                                    break;
                                case CardType.CultureCard:
                                    card = new CultureCard();
                                    break;
                                case CardType.ResourceCard:
                                    card = new ResourceCard();
                                    break;
                                case CardType.ScienceCard:
                                    card = new ScienceCard();
                                    break;
                                default:
                                    card = new TradeCard();
                                    break;
                            }
                            Read(reader, card);
                            result.Add(card);
                        }
                    }
                }
                objConnection.Close();
            }
            return result;
        }

        private static void Read(SQLiteDataReader reader, Card card)
        {
            card.Id = reader.GetInt32(0);
            card.Text = reader.GetString(1);
            card.UniqCardId = reader.GetInt32(2);
            card.CardType = reader.GetInt32(3);
            card.Epoch = reader.GetInt32(4);
            card.MinPlayers = reader.GetInt32(5);
            card.Wood = reader.GetInt32(6);
            card.Stone = reader.GetInt32(7);
            card.Gold = reader.GetInt32(8);
            card.Brick = reader.GetInt32(9);
            card.Papirus = reader.GetInt32(10);
            card.Glass = reader.GetInt32(11);
            card.Cloth = reader.GetInt32(12);
            card.CardBenefit = reader.GetInt32(13);
            card.CoinsCost = reader.GetInt32(14);
            card.ParentUniqCard = reader.GetInt32(15);
        }
    }
}

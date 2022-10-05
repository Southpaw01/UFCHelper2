using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Models;
using Xamarin.Forms;

namespace WorkWithDB
{
    public static class ReadingDB
    {
        public static Task<List<WeightCategory>> GetWeightCategories()
        {
            return Task.Run(() =>
             {
                 List<WeightCategory> weights = new List<WeightCategory>();
                 string nameProc = "GetWeightCtgs";

                 using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                 {
                     connection.Open();
                     SqlCommand command = new SqlCommand(nameProc, connection)
                     {
                         CommandType = CommandType.StoredProcedure
                     };

                     SqlDataReader reader = command.ExecuteReader();

                     while(reader.Read())
                     {
                         WeightCategory weight = new WeightCategory()
                         {
                             Name = reader.GetString(1),
                             WFrom = reader.GetDouble(2),
                             WTo = reader.GetDouble(3)
                         };
                         weights.Add(weight);
                     }

                     return weights;
                 }
             });
        }

        public static Task<List<Fighter>> GetRating(string division)
        {
            return Task.Run(() =>
            {
                List<Fighter> fighters = new List<Fighter>();

                string nameProc = "GetRatingFightersOfWeight";
                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlDivision = new SqlParameter()
                    {
                        ParameterName = "@division",
                        Value = division
                    };

                    command.Parameters.Add(sqlDivision);

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {     
                        Fighter fighter = new Fighter()
                        {
                            Name = reader.GetString(0),
                            Surname = reader.GetString(1),
                            Wins = reader.GetInt32(2),
                            Loses = reader.GetInt32(3),
                            Draws = reader.GetInt32(4),
                            NoContests = reader.GetInt32(5),
                            NumRating = reader.GetString(6),
                            SmallPhoto = new UriImageSource() { Uri = new Uri(reader.GetString(7)) }
                        };

                        fighters.Add(fighter);
                    }

                    return fighters;
                }
            });
        }

        public static Task<List<Tournament>> GetUpcomingTournaments()
        {
            return Task.Run(() =>
            {
                List<Tournament> weights = new List<Tournament>();
                string nameProc = "GetUpcomingTournaments";

                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Tournament tournament = new Tournament()
                        {
                            Name = reader.GetString(0),
                            Date = reader.GetDateTime(1),
                            Place = reader.GetString(2)
                        };
                        weights.Add(tournament);
                    }

                    return weights;
                }
            });
        }

        public static Task<List<Tournament>> GetFinishedTournaments()
        {
            return Task.Run(() =>
            {
                List<Tournament> weights = new List<Tournament>();
                string nameProc = "GetFinishedTournaments";

                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Tournament tournament = new Tournament()
                        {
                            Name = reader.GetString(0),
                            Date = reader.GetDateTime(1),
                            Place = reader.GetString(2)
                        };
                        weights.Add(tournament);
                    }

                    return weights;
                }
            });
        }

        public static Task<string> GetSmallImageOfFighter(Fighter fighter)
        {
            return Task.Run(() =>
            {
                string nameProc = "GetSmallImage";

                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter Name = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = fighter.Name
                    };

                    SqlParameter Surname = new SqlParameter()
                    {
                        ParameterName = "@Surname",
                        Value = fighter.Surname
                    };

                    command.Parameters.Add(Name);
                    command.Parameters.Add(Surname);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        return reader.GetString(0);
                    return "";
                }
            });
        }

        public static Task<Fighter> GetAllDataAboutFighter(string name, string surname)
        {
            return Task.Run(() =>
            {
                Fighter fighter = new Fighter();
                fighter = GetAllDataAboutFighter(fighter, name, surname);
                fighter = GetRecordOfFighter(fighter);
                fighter = GetAnthropometryOfFighter(fighter);

                return fighter;
            });
        }
        public static Fighter GetAllDataAboutFighter(Fighter fighter, string name, string surname)
        {
            string nameProc = "GetMainDataAboutFighter";
            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter Name = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = name
                };

                SqlParameter Surname = new SqlParameter()
                {
                    ParameterName = "@Surname",
                    Value = surname
                };

                command.Parameters.Add(Name);
                command.Parameters.Add(Surname);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    fighter.Name = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                        fighter.Alias = reader.GetString(1);
                    fighter.Surname = reader.GetString(2);
                    fighter.Country = reader.GetString(3);
                    fighter.Debut = reader.GetDateTime(4);
                    fighter.WeightCategory = reader.GetString(5);
                    fighter.SmallPhoto = new UriImageSource() { Uri = new Uri(reader.GetString(6)) };
                    fighter.BigPhoto = new UriImageSource() { Uri = new Uri(reader.GetString(7)) };
                }

                return fighter;
            }
        }
        public static Fighter GetRecordOfFighter(Fighter fighter)
        {
            string nameProc = "GetRecordOfFighter";
            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter Name = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = fighter.Name
                };

                SqlParameter Surname = new SqlParameter()
                {
                    ParameterName = "@Surname",
                    Value = fighter.Surname
                };

                command.Parameters.Add(Name);
                command.Parameters.Add(Surname);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    fighter.Wins = reader.GetInt32(0);
                    fighter.Loses = reader.GetInt32(1);
                    fighter.Draws = reader.GetInt32(2);
                    fighter.NoContests = reader.GetInt32(3);
                }

                return fighter;
            }
        }
        public static Fighter GetAnthropometryOfFighter(Fighter fighter)
        {
            string nameProc = "GetAnthropometryOfFighter";
            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter Name = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = fighter.Name
                };

                SqlParameter Surname = new SqlParameter()
                {
                    ParameterName = "@Surname",
                    Value = fighter.Surname
                };

                command.Parameters.Add(Name);
                command.Parameters.Add(Surname);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    fighter.Gender = reader.GetString(0);
                    fighter.Age = reader.GetInt32(1);
                    fighter.Height = reader.GetDouble(2);
                    fighter.Weight = reader.GetDouble(3);
                    fighter.ArmSpan = reader.GetDouble(4);
                    fighter.LegSpan = reader.GetDouble(5);
                }


                return fighter;
            }
        }


        public static Task<List<Fight>> GetFightsOfFighter(string name, string surname)
        {
            return Task.Run(() =>
            {
                List<Fight> fights = new List<Fight>();
                string nameProc = "GetFightsOfFighter";

                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter Name = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = name
                    };

                    SqlParameter Surname = new SqlParameter()
                    {
                        ParameterName = "@Surname",
                        Value = surname
                    };

                    command.Parameters.Add(Name);
                    command.Parameters.Add(Surname);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Fight fight = new Fight()
                            {
                                Name = reader.GetString(0),
                            };
                            fights.Add(fight);
                        }
                    }

                    return fights;
                }
            });
        }

        public static Task<Tournament> GetInformationAboutTournament(string name)
        {
            return Task.Run(() =>
            {
                string nameProc = "GetInformationAboutTournament";

                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter Name = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = name
                    };

                    command.Parameters.Add(Name);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    return new Tournament()
                    {
                        Name = reader.GetString(1),
                        Date = reader.GetDateTime(2),
                        Place = reader.GetString(3),
                        Status = reader.GetString(4),
                    };
                }
            });
        }

        public static Task<List<Fight>> GetFightsOfTournament(string name)
        {
            return Task.Run(() =>
            {
                string nameProc = "GetFightsOfTournament";

                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter Name = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = name
                    };

                    command.Parameters.Add(Name);

                    SqlDataReader reader = command.ExecuteReader();

                    List<Fight> fights = new List<Fight>();
                    try
                    {
                        while(reader.Read())
                        {
                            Fight fight = new Fight()
                            {
                                Name = reader.GetString(0),
                                Number = reader.GetInt32(1)
                            };

                            fights.Add(fight);
                        }

                        return fights;
                    }
                    catch
                    {
                        return fights;
                    }
                }
            });
        }

        public static Fight GetInformationAboutFight(string name)
        {
                string nameProc = "GetInformationAboutFight";
                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter Name = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = name
                    };

                    command.Parameters.Add(Name);

                    SqlDataReader reader = command.ExecuteReader();

                    Fight fight = new Fight() { Name = name };

                    if (reader.Read())
                    {
                        try
                        {
                            fight.WinnerName = reader.GetString(0) + " " + reader.GetString(1);
                        }
                        catch
                        {
                            fight.WinnerName = "-";
                        }

                        try
                        {
                            fight.Result = reader.GetString(2);
                        }
                        catch { fight.Result = "-"; }

                        fight.Weight = reader.GetString(3);
                        fight.Tournament = reader.GetString(4);

                        fight.Round = reader.GetInt32(5);
                        fight.Time = reader.GetTimeSpan(6);

                        fight.Type = reader.GetString(7);

                        try
                        {
                            fight.Note = reader.GetString(8);
                        }
                        catch
                        {
                            fight.Note = "-";
                        }
                        fight.Number = reader.GetInt32(9);
                        fight.Name = reader.GetString(10);
                    }

                    return fight;
                }
        }

        public static List<Round> GetStatsByRoundsOfFighter(string fighterName, string fighterSurname, string fightName)
        {
                string nameProc = "GetStatsByRoundsOfFighter";
                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter Name = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = fighterName
                    };

                    SqlParameter Surname = new SqlParameter()
                    {
                        ParameterName = "@Surname",
                        Value = fighterSurname
                    };

                    SqlParameter FightName = new SqlParameter()
                    {
                        ParameterName = "@FightName",
                        Value = fightName
                    };

                    command.Parameters.Add(Name);
                    command.Parameters.Add(Surname);
                    command.Parameters.Add(FightName);

                    SqlDataReader reader = command.ExecuteReader();

                    List<Round> rounds = new List<Round>();
                    while(reader.Read())
                    {
                        Round round = new Round()
                        {
                            Number = reader.GetInt32(0),
                            Punches = reader.GetInt32(1),
                            AllPunches = reader.GetInt32(2),
                            AccPunches = reader.GetInt32(3),
                            AllAccPunches = reader.GetInt32(4),
                            Takedowns = reader.GetInt32(5),
                            TryTakedowns = reader.GetInt32(6),
                        };

                        rounds.Add(round);
                    }

                    return rounds;
                }
        }

        public static List<Fighter> GetInformationAboutFightersFromFight(string fightName)
        {
                string nameProc = "GetInformationAboutFightersFromFight";
                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter Name = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = fightName
                    };

                    command.Parameters.Add(Name);

                    SqlDataReader reader = command.ExecuteReader();

                    List<Fighter> fighters = new List<Fighter>();
                    while(reader.Read())
                    {
                        Fighter fighter = new Fighter()
                        {
                            Name = reader.GetString(0),
                            Surname = reader.GetString(1),
                            SmallPhoto = new UriImageSource() { Uri = new Uri(reader.GetString(2)) }
                        };

                        fighters.Add(fighter);
                    }

                    return fighters;
                }
        }

        public static Task<ObservableCollection<string>> GetPossibleResults()
        {
            return Task.Run(() =>
            {
                string nameProc = "GetPossibleResults";
                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    ObservableCollection<string> results = new ObservableCollection<string>();
                    while(reader.Read())
                    { 
                        results.Add(reader.GetString(0));
                    }

                    return results;
                }
            });
        }

        public static Task<List<Fighter>> GetAllFighters()
        {
            return Task.Run(() =>
            {
                List<Fighter> fighters = new List<Fighter>();

                string nameProc = "GetAllFighters";
                using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(nameProc, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Fighter fighter = new Fighter()
                        {
                            Name = reader.GetString(0),
                            Surname = reader.GetString(1),
                            SmallPhoto = new UriImageSource() { Uri = new Uri(reader.GetString(2)) },
                            WeightCategory = reader.GetString(3),
                        };

                        fighters.Add(fighter);
                    }

                    return fighters;
                }
            });
        }
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDB
{
    public static class StatsDB
    {
        public static Task<int> CountOfFightByNameFight(string name)
        {
            return Task.Run(() =>
            {
                string nameProc = "CountOfFightByName";

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

                    if (reader.HasRows)
                        return reader.GetInt32(0);
                    return 0;
                }
            });
        }

        public static Task<StatsFighter> GetSumOfPunchesAndTakedownsForAllTime(string name, string surname)
        {
            return Task.Run(() =>
            {
                string nameProc = "GetSumOfPunchesAndTakedowns";

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
                        try
                        {
                            return new StatsFighter()
                            {
                                Punches = reader.GetInt32(0),
                                AllPunches = reader.GetInt32(1),
                                AccPunches = reader.GetInt32(2),
                                AllAccPunches = reader.GetInt32(3),
                                Takedowns = reader.GetInt32(4),
                                TryTakedowns = reader.GetInt32(5),
                            };
                        }
                        catch
                        {
                            return new StatsFighter();
                        }
                    }
                    else return new StatsFighter();
                }
            });
        }

        public static Task<int> CountOfFightsInUFC(string name, string surname)
    {
        return Task.Run(() =>
        {
            string nameProc = "CountOfFightsInUFC";

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
                    return reader.GetInt32(0);
                else return 0;
            }
        });
    }

        public static Task<StatsFighter> SumPunchesAndTakedownsInOneFight(string name, string surname, string fightName)
        {
            return Task.Run(() =>
            {
                string nameProc = "SumPunchesAndTakedownsInOneFight";

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

                    SqlParameter FightName = new SqlParameter()
                    {
                        ParameterName = "@FightName",
                        Value = fightName
                    };

                    command.Parameters.Add(Name);
                    command.Parameters.Add(Surname);
                    command.Parameters.Add(FightName);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            return new StatsFighter()
                            {
                                Punches = reader.GetInt32(0),
                                AllPunches = reader.GetInt32(1),
                                AccPunches = reader.GetInt32(2),
                                AllAccPunches = reader.GetInt32(3),
                                Takedowns = reader.GetInt32(4),
                                TryTakedowns = reader.GetInt32(5),
                            };
                        }
                        catch
                        {
                            return new StatsFighter();
                        }
                    }
                    else return new StatsFighter();
                }
            });
        }
    }
}

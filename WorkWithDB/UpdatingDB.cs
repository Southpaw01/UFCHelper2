using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace WorkWithDB
{
    public static class UpdatingDB
    {

        public static void AddAllDataAboutFighter(Fighter fighter)
        {
            AddFighter(fighter);
            AddRecord(fighter);
            AddAnthropometry(fighter);
            AddImages(fighter);
            AddFighterToWeightCategory(fighter);
        }

        public static void AddFighter(Fighter fighter)
        {
            string nameProc = "AddFighter";

            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters
                SqlParameter sqlName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = fighter.Name
                };

                if (fighter.Alias != null)
                {
                    SqlParameter sqlAlias = new SqlParameter
                    {
                        ParameterName = "@Alias",
                        Value = fighter.Alias,
                    };
                    command.Parameters.Add(sqlAlias);
                }
                SqlParameter sqlSurname = new SqlParameter
                {
                    ParameterName = "@Surname",
                    Value = fighter.Surname
                };
                SqlParameter sqlCountry = new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = fighter.Country
                };
                SqlParameter sqlDebut = new SqlParameter
                {
                    ParameterName = "@Debut",
                    Value = fighter.Debut
                };
                SqlParameter sqlWeight = new SqlParameter
                {
                    ParameterName = "@Weight",
                    Value = fighter.WeightCategory
                };
                #endregion

                command.Parameters.Add(sqlName);
                command.Parameters.Add(sqlSurname);
                command.Parameters.Add(sqlCountry);
                command.Parameters.Add(sqlDebut);
                command.Parameters.Add(sqlWeight);

                command.ExecuteNonQuery();
            }
        }

        public static void AddRecord(Fighter fighter)
        {
            string nameProc = "AddRecord";

            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters
                SqlParameter sqlName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = fighter.Name
                };
                SqlParameter sqlSurname = new SqlParameter
                {
                    ParameterName = "@Surname",
                    Value = fighter.Surname
                };
                SqlParameter sqlCountry = new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = fighter.Country
                };
                SqlParameter sqlDebut = new SqlParameter
                {
                    ParameterName = "@Debut",
                    Value = fighter.Debut
                };
                SqlParameter sqlWins = new SqlParameter
                {
                    ParameterName = "@Wins",
                    Value = fighter.Wins
                };
                SqlParameter sqlLoses = new SqlParameter
                {
                    ParameterName = "@Loses",
                    Value = fighter.Loses
                };
                SqlParameter sqlDraws = new SqlParameter
                {
                    ParameterName = "@Draws",
                    Value = fighter.Draws
                };
                SqlParameter sqlNoContests = new SqlParameter
                {
                    ParameterName = "@NoContest",
                    Value = fighter.NoContests
                };
                #endregion

                command.Parameters.Add(sqlName);
                command.Parameters.Add(sqlSurname);
                command.Parameters.Add(sqlCountry);
                command.Parameters.Add(sqlDebut);
                command.Parameters.Add(sqlWins);
                command.Parameters.Add(sqlLoses);
                command.Parameters.Add(sqlDraws);
                command.Parameters.Add(sqlNoContests);

                command.ExecuteNonQuery();
            }
        }

        public static void AddAnthropometry(Fighter fighter)
        {
            string nameProc = "AddAnthropometry";

            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters
                SqlParameter sqlName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = fighter.Name
                };
                SqlParameter sqlSurname = new SqlParameter
                {
                    ParameterName = "@Surname",
                    Value = fighter.Surname
                };
                SqlParameter sqlCountry = new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = fighter.Country
                };
                SqlParameter sqlDebut = new SqlParameter
                {
                    ParameterName = "@Debut",
                    Value = fighter.Debut
                };
                SqlParameter sqlGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = fighter.Gender
                };
                SqlParameter sqlAge = new SqlParameter
                {
                    ParameterName = "@Age",
                    Value = fighter.Age
                };
                SqlParameter sqlHeight = new SqlParameter
                {
                    ParameterName = "@Height",
                    Value = fighter.Height
                };
                SqlParameter sqlWeight = new SqlParameter
                {
                    ParameterName = "@Weight",
                    Value = fighter.Weight
                };

                SqlParameter sqlArmSpan = new SqlParameter
                {
                    ParameterName = "@ArmSpan",
                    Value = fighter.ArmSpan
                };

                SqlParameter sqlLegSpan = new SqlParameter
                {
                    ParameterName = "@LegSpan",
                    Value = fighter.LegSpan
                };
                #endregion

                command.Parameters.Add(sqlLegSpan);
                command.Parameters.Add(sqlArmSpan);
                command.Parameters.Add(sqlName);
                command.Parameters.Add(sqlSurname);
                command.Parameters.Add(sqlCountry);
                command.Parameters.Add(sqlDebut);
                command.Parameters.Add(sqlGender);
                command.Parameters.Add(sqlAge);
                command.Parameters.Add(sqlHeight);
                command.Parameters.Add(sqlWeight);

                command.ExecuteNonQuery();
            }
        }

        public static void AddImages(Fighter fighter)
        {
            string nameProc = "AddImages";

            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters
                SqlParameter sqlName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = fighter.Name
                };
                SqlParameter sqlSurname = new SqlParameter
                {
                    ParameterName = "@Surname",
                    Value = fighter.Surname
                };
                SqlParameter sqlCountry = new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = fighter.Country
                };
                SqlParameter sqlDebut = new SqlParameter
                {
                    ParameterName = "@Debut",
                    Value = fighter.Debut
                };
                SqlParameter sqlSmallPhoto = new SqlParameter
                {
                    ParameterName = "@SmallPhoto",
                    Value = fighter.SmallPhoto.Uri.ToString()
                };
                SqlParameter sqlBigPhoto = new SqlParameter
                {
                    ParameterName = "@BigPhoto",
                    Value = fighter.BigPhoto.Uri.ToString()
                };
                #endregion

                command.Parameters.Add(sqlName);
                command.Parameters.Add(sqlSurname);
                command.Parameters.Add(sqlCountry);
                command.Parameters.Add(sqlDebut);
                command.Parameters.Add(sqlSmallPhoto);
                command.Parameters.Add(sqlBigPhoto);

                command.ExecuteNonQuery();
            }
        }

        public static void AddTournament(Tournament tournament)
        {
            string nameProc = "AddTournament";

            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters
                SqlParameter sqlName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = tournament.Name
                };
                SqlParameter sqlDate = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = tournament.Date
                };
                SqlParameter sqlPlace = new SqlParameter
                {
                    ParameterName = "@Place",
                    Value = tournament.Place
                };
                SqlParameter sqlStatus = new SqlParameter
                {
                    ParameterName = "@Status",
                    Value = tournament.Status
                };
                #endregion

                command.Parameters.Add(sqlName);
                command.Parameters.Add(sqlDate);
                command.Parameters.Add(sqlPlace);
                command.Parameters.Add(sqlStatus);

                command.ExecuteNonQuery();
            }
        }

        public static void AddFighterToWeightCategory(Fighter fighter)
        {
            string nameProc = "AddFighterToWeightCategory";

            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters
                SqlParameter sqlFigterName = new SqlParameter
                {
                    ParameterName = "@FighterName",
                    Value = fighter.Name
                };

                SqlParameter sqlFighterSurname = new SqlParameter
                {
                    ParameterName = "@FighterSurname",
                    Value = fighter.Surname
                };

                SqlParameter sqlDebut = new SqlParameter
                {
                    ParameterName = "@Debut",
                    Value = fighter.Debut
                };
                SqlParameter sqlWeightName = new SqlParameter
                {
                    ParameterName = "@WeightName",
                    Value = fighter.WeightCategory
                };
                if (fighter.NumRating != null)
                {
                    SqlParameter sqlNumRating = new SqlParameter
                    {
                        ParameterName = "@NumRating",
                        Value = fighter.NumRating
                    };
                    command.Parameters.Add(sqlNumRating);
                }
                #endregion

                command.Parameters.Add(sqlFigterName);
                command.Parameters.Add(sqlFighterSurname);
                command.Parameters.Add(sqlDebut);
                command.Parameters.Add(sqlWeightName);

                command.ExecuteNonQuery();
            }
        }

        public static void AddFight(Fight fight)
        {
            string nameProc = "";

            string surname = "";
            string name = "";
            if (fight.WinnerName != "Нет победителя" && fight.WinnerName != null)
            {
                string[] div = fight.WinnerName.Split(' ');
                for (int i = 1; i < div.Length; i++)
                {
                    name = div[0];
                    surname += div[i] + " ";
                }
                nameProc = "AddFightWithWinner";
            }
            else nameProc = "AddFightWithoutWinner";


            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters

                if (name != "")
                {
                    SqlParameter WinnerName = new SqlParameter
                    {
                        ParameterName = "@WinnerName",
                        Value = name
                    };
                    command.Parameters.Add(WinnerName);
                }
                if (surname != "")
                {
                    SqlParameter WinnerSurname = new SqlParameter
                    {
                        ParameterName = "@WinnerSurname",
                        Value = surname
                    };
                    command.Parameters.Add(WinnerSurname);
                }
                SqlParameter Num = new SqlParameter()
                {
                    ParameterName = "@num",
                    Value = fight.Number
                };

                SqlParameter WeightName = new SqlParameter
                {
                    ParameterName = "@WeightCtg",
                    Value = fight.Weight
                };

                SqlParameter sqlResult = new SqlParameter
                {
                    ParameterName = "@Result",
                    Value = fight.Result
                };
                command.Parameters.Add(sqlResult);

                SqlParameter Round = new SqlParameter
                {
                    ParameterName = "@Round",
                    Value = fight.Round
                };
                if (fight.Time != null)
                {
                    SqlParameter sqlTime = new SqlParameter
                    {
                        ParameterName = "@Time",
                        Value = "00:" + fight.Time
                    };
                    command.Parameters.Add(sqlTime);
                }

                SqlParameter Tournament = new SqlParameter
                {
                    ParameterName = "@Tournament",
                    Value = fight.Tournament
                };
                SqlParameter Type = new SqlParameter
                {
                    ParameterName = "@Type",
                    Value = fight.Type
                };

                if (fight.Note != null)
                {
                    SqlParameter sqlNote = new SqlParameter
                    {
                        ParameterName = "@Note",
                        Value = fight.Note
                    };
                    command.Parameters.Add(sqlNote);
                }
                SqlParameter Name = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = fight.Name
                };
                #endregion

                command.Parameters.Add(Round);
                command.Parameters.Add(Num);
                command.Parameters.Add(WeightName);
                command.Parameters.Add(Tournament);
                command.Parameters.Add(Type);
                command.Parameters.Add(Name);

                command.ExecuteNonQuery();
            }
        }

        public static void AddStatsFight(Fight fight, Fighter fighter, Round round)
        {
            string nameProc = "AddStatsFight";

            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters
                SqlParameter sqlFightName = new SqlParameter
                {
                    ParameterName = "@FightName",
                    Value = fight.Name
                };

                SqlParameter sqlFighterN = new SqlParameter
                {
                    ParameterName = "@FighterN",
                    Value = fighter.Name
                };

                SqlParameter sqlFighterSN = new SqlParameter
                {
                    ParameterName = "@FighterSN",
                    Value = fighter.Surname
                };
                SqlParameter sqlNumRound = new SqlParameter
                {
                    ParameterName = "@NumRound",
                    Value = round.Number
                };

                SqlParameter sqlPunches = new SqlParameter
                {
                    ParameterName = "@Punches",
                    Value = round.Punches
                };

                SqlParameter sqlAllPunches = new SqlParameter
                {
                    ParameterName = "@AllPunches",
                    Value = round.AllPunches
                };

                SqlParameter sqlAccPunches = new SqlParameter
                {
                    ParameterName = "@AccPunches",
                    Value = round.AccPunches
                };
                SqlParameter sqlAllAccPunches = new SqlParameter
                {
                    ParameterName = "@AllAccPunches",
                    Value = round.AllAccPunches
                };

                SqlParameter sqlTakedowns = new SqlParameter
                {
                    ParameterName = "@Takedowns",
                    Value = round.Takedowns
                };
                SqlParameter sqlTryTakedowns = new SqlParameter
                {
                    ParameterName = "@TryTakedowns",
                    Value = round.TryTakedowns
                };

                #endregion

                command.Parameters.Add(sqlTryTakedowns);
                command.Parameters.Add(sqlTakedowns);
                command.Parameters.Add(sqlAllAccPunches);
                command.Parameters.Add(sqlAccPunches);
                command.Parameters.Add(sqlAllPunches);
                command.Parameters.Add(sqlPunches);
                command.Parameters.Add(sqlFightName);
                command.Parameters.Add(sqlFighterN);
                command.Parameters.Add(sqlFighterSN);
                command.Parameters.Add(sqlNumRound);

                command.ExecuteNonQuery();
            }
        }

    }
}

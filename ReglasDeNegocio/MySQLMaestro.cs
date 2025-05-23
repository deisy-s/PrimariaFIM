using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;

namespace ReglasDeNegocio
{
    public class MySQLMaestro
    {
        public string sError, sConnection;
        private string sServer = "localhost";
        private string sUser = "root";
        private string sPass = "12345";

        public bool TeacherLogin(ref DataTable table)
        {
            bool bOk = false;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = "SELECT Username, Pass FROM registro_user;"; // Query para obtener todos los registros de usuario y contraseña

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool TeacherLogin(ref DataTable table, int id)
        {
            bool bOk = false;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT Username, Pass FROM registro_user WHERE idMaestro = {id};"; // Query para obtener user y password de un maestro

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public int GetID(string user, string pass)
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idMaestro from registro_user WHERE Username = '{user}' AND Pass = '{pass}';", conMySQL)) // Query para obtener el id de maestro de un login
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public int GetID(int grade)
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT maestro.idMaestro from maestro INNER JOIN grupo WHERE maestro.Grupo = grupo.idGrupo AND grupo.idGrupo = {grade};", conMySQL)) // Query para obtener el id de un maestro de un grado
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public int GetGrade(int id)
        {
            int grade = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el grado al que está asignado un maestro
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM maestro WHERE idMaestro = {id};", conMySQL)) 
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grade = Convert.ToInt16(reader[3]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return grade;
        }

        public string GetName(int id)
        {
            string user = string.Empty;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el nombre y apellido de un maestro
                using (MySqlCommand cmd = new MySqlCommand($"SELECT maestro.Nombre, maestro.Apellidos FROM maestro INNER JOIN registro_user WHERE maestro.idMaestro = registro_user.idMaestro AND maestro.idMaestro = {id};", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader[0].ToString(); // Almacena el nombre
                            string apellido = reader[1].ToString(); // Almacena el apellido
                            user = nombre + " " + apellido; // Concatena en el mismo string
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return user;
        }

        public void GetStudents(ref DataTable table, int group)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM alumno WHERE idGrupo = {group};"; // Obtener  todos alumnos del grupo

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public bool CheckLoginInfo(string user)
        {
            bool check = false;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    // Obtener la información del registro donde el nombre de usuario es igual al ingresado
                    string sQry = $"select * from registro_user where Username = '{user}';";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            check = true;
                        }
                        reader.Close();
                    }
                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return check;
        }

        public void GetStudentsList(ref DataTable table, int group)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    // Obtener una lista de los alumnos, regresando solamente su id y nombre (ordenado por apellido)
                    string sQry = $"SELECT idAlumno, CONCAT(Apellidos, ' ', Nombre) As Nombre FROM alumno WHERE idGrupo = {group} ORDER BY Apellidos;";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetStudent(ref DataTable table, int i)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM alumno where idAlumno = {i};"; // Obtener la información de 1 alumno

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetStudentName(ref DataTable table, int id)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    // Obtener el id y nombre completo de un alumnno
                    string sQry = $"SELECT idAlumno, CONCAT(Nombre, ' ', Apellidos) As Nombre FROM alumno WHERE idAlumno = {id};";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public bool AddStudent(int id, string name, string lname, int grade)
        {
            bool bOk = false;
            try
            {
                int teacher = GetID(grade);
                string sQry = $"INSERT INTO alumno VALUES ({id}, '{name}', '{lname}', {teacher}, {grade});"; // Agregar un alumno
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool ModifyStudent(int id, string name, string lname, int grade)
        {
            bool bOk = false;
            try
            {
                int teacher = GetID(grade);
                // Query para actualizar la información general de alumno
                string sQry = $"UPDATE alumno SET Nombre = '{name}', Apellidos = '{lname}', idMaestro = {teacher}, idGrupo = {grade} WHERE idAlumno = {id};";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool DeleteStudent(int id)
        {
            bool bOk = false;
            try
            {
                string sQry = $"DELETE FROM sisat_calculo_mental WHERE idAlumno = {id}; DELETE FROM sisat_produccion_textos WHERE idAlumno = {id}; DELETE FROM sisat_toma_lectura WHERE idAlumno = {id}; DELETE FROM materias WHERE idAlumno = {id}; DELETE FROM reporte_calificaciones WHERE idAlumno = {id}; DELETE FROM alumno where idAlumno = {id};"; // Eliminar un alumno
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public int LastID()
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand("SELECT MAX(idAlumno) FROM alumno;", conMySQL)) // Query para obtener el último id de alumnos
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public List<int> GetIDName(string name, int group)
        {
            List<int> id = new List<int>();
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el id de alumno de acuerdo a su nombre
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idAlumno, LOCATE('{name}',Nombre) FROM alumno WHERE idGrupo = {group};", conMySQL)) 
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToInt16(reader[1]) != 0)
                            {
                                id.Add(Convert.ToInt16(reader[0]));
                            }
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public List<int> GetIDLastName(string name, int group)
        {
            List<int> id = new List<int>();
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el id de alumno de acuerdo a su apellido
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idAlumno, LOCATE('{name}',Apellidos) FROM alumno WHERE idGrupo = {group};", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToInt16(reader[1]) != 0)
                            {
                                id.Add(Convert.ToInt16(reader[0]));
                            }
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public int GetStudentGrade(int id)
        {
            int grade = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para encontrar el grado de un alumno
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idGrupo FROM alumno WHERE idAlumno = {id};", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grade = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return grade;
        }

        public bool UpdateGroup(int grade)
        {
            bool bOk = false;
            try
            {
                int students = CountStudents(grade);
                string sQry = $"UPDATE grupo SET CantidadAlumnos = {students} where idGrupo = {grade};"; // Actualizar la cantidad de alumnos en un grupo
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public int CountStudents(int grade)
        {
            int students = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para contar la cantidad de alumnos en un grupo
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) as Num from alumno INNER JOIN grupo WHERE alumno.idGrupo = grupo.idGrupo AND grupo.idGrupo = {grade};", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return students;
        }

        public bool ModifyTeacher(int id, string user, string pass)
        {
            bool bOk = false;
            try
            {
                // Query para actualizar la información de inicio de sesión
                string sQry = $"UPDATE registro_user SET Username = '{user}', Pass = '{pass}' WHERE idMaestro = {id}"; 
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool AddGrade(int id, float language, float knowledge, float ethics, float humanity, float final, string observations, string name, int grade, string periodo, string year)
        {
            bool bOk = false;
            try
            {
                // Query para actualizar la información de inicio de sesión
                string sQry = $"INSERT INTO reporte_calificaciones (idAlumno, CalFinal, Maestro, Grado, Observaciones, Periodo, CicloEscolar) VALUES ({id}, {final}, '{name}', {grade}, '{observations}', '{periodo}', '{year}');";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();

                string rID = GetLastReport();
                int r = 0;
                if (string.IsNullOrEmpty(rID))
                {
                    r = 1;
                }
                else
                {
                    r = Convert.ToInt16(rID);
                }
                AddIndGrade(1, id, r, language, periodo, year);
                AddIndGrade(2, id, r, knowledge, periodo, year);
                AddIndGrade(3, id, r, ethics, periodo, year);
                AddIndGrade(4, id, r, humanity, periodo, year);
                
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool AddIndGrade(int mID, int id, int rID, float grade, string periodo, string year)
        {
            bool bOk = false;
            string name;
            try
            {
                switch (mID)
                {
                    case 1:
                        name = "LENGUAJES";
                        break;
                    case 2:
                        name = "SABERES Y PENSAMIENTO CIENTIFICO";
                        break;
                    case 3:
                        name = "ETICA, NATURALEZA Y SOCIECADES";
                        break;
                    case 4:
                        name = "DE LO HUMANO Y LO COMUNITARIO";
                        break;
                    default:
                        return false;
                }
                // Query para actualizar la información de inicio de sesión
                string sQry = $"INSERT INTO materias (idMaterias, idAlumno, idReporte, Nombre, Calificacion, Periodo, CicloEscolar) VALUES ({mID}, {id}, {rID}, '{name}', {grade}, '{periodo}', '{year}');";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool UpdateGrade(int id, float language, float knowledge, float ethics, float humanity, float final, string observations, string periodo, int group, string year)
        {
            bool bOk = false;
            try
            {
                // Query para actualizar la información de inicio de sesión
                string sQry = $"UPDATE reporte_calificaciones SET CalFinal = {final}, Observaciones = '{observations}' WHERE idAlumno = {id} and Periodo = '{periodo}' AND Grado = {group} AND CicloEscolar = '{year}';";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
                int rID = GetRID(id, periodo, group);
                UpdateIndGrade(1, id, language, periodo, rID, year);
                UpdateIndGrade(2, id, knowledge, periodo, rID, year);
                UpdateIndGrade(3, id, ethics, periodo, rID, year);
                UpdateIndGrade(4, id, humanity, periodo, rID, year);
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        private bool UpdateIndGrade(int mID, int id, float grade, string periodo, int rID, string year)
        {
            bool bOk = false;
            try
            {
                // Query para actualizar la información de inicio de sesión
                string sQry = $"UPDATE materias SET Calificacion = {grade} WHERE idAlumno = {id} AND idMaterias = {mID} AND Periodo = '{periodo}' AND idReporte = {rID} AND CicloEscolar = '{year}';";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        private string GetLastReport()
        {
            string id = "";
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el grado al que está asignado un maestro
                using (MySqlCommand cmd = new MySqlCommand($"SELECT MAX(idReporteCal) from reporte_calificaciones;", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader[0].ToString();
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        private int GetRID(int aID, string period, int grade)
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el grado al que está asignado un maestro
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idReporteCal FROM reporte_calificaciones WHERE idAlumno = {aID} and Periodo = '{period}' AND Grado = {grade};", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public void GetGrades(ref DataTable table, int id, string periodo, string year)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    // Obtener promedio final, nombre y observaciones de alumnos
                    string sQry = $"SELECT r.idAlumno, r.CalFinal, CONCAT(a.Nombre, ' ', a.Apellidos) As Nombre, r.Observaciones from reporte_calificaciones as r inner join alumno as a where r.idAlumno = a.idAlumno AND r.idAlumno = {id} AND r.Periodo = '{periodo}' AND r.CicloEscolar = '{year}';";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetGrades2(ref DataTable table, int id, string periodo, string year)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    // Obtener la calificación de cada materia de un alumno
                    string sQry = $"select m.Nombre, m.Calificacion from materias as m inner join alumno as a inner join reporte_calificaciones as r where a.idAlumno = m.idAlumno AND r.idReporteCal = m.idReporte AND m.Periodo = '{periodo}' AND a.idAlumno = {id} AND m.CicloEscolar = '{year}';";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public bool AddCM(int id, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, int final, string na, string observations, string teachName, string period, int grade, string year)
        {
            bool bOk = false;
            int cm;
            try
            {
                string idCM = GetLastCMId();
                if (string.IsNullOrEmpty(idCM))
                {
                    cm = 1;
                }
                else
                {
                    cm = Convert.ToInt16(idCM);
                    cm++;
                }
                // Query para guardar calificaciones de la evaluación de cálculo mental
                string sQry = $"INSERT INTO sisat_calculo_mental (idSisATCM, idAlumno, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, PFinal, Observaciones, NivelAprendizaje, Maestro, Periodo, Grado, CicloEscolar) VALUES ({cm}, {id}, '{p1}', '{p2}', '{p3}', '{p4}', '{p5}', '{p6}', '{p7}', '{p8}', '{p9}', '{p10}', {final}, '{observations}', '{na}', '{teachName}', '{period}', {grade}, '{year}');";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public string GetLastCMId()
        {
            string id = "";
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el último id
                using (MySqlCommand cmd = new MySqlCommand($"SELECT MAX(idSisATCM) from sisat_calculo_mental;", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader[0].ToString();
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public bool UpdateCM(int id, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, int final, string na, string observations, string period, int group, string year)
        {
            bool bOk = false;
            try
            {
                // Query para actualizar las calificaciones de cálculo mental
                string sQry = $"UPDATE sisat_calculo_mental SET P1 = '{p1}', P2 = '{p2}', P3 = '{p3}', P4 = '{p4}', P5 = '{p5}', P6 = '{p6}', P7 = '{p7}', P8 = '{p8}', P9 = '{p9}', P10 = '{p10}', PFinal = '{final}', Observaciones = '{observations}', NivelAprendizaje = '{na}' WHERE idAlumno = {id} AND Periodo = '{period}' AND Grado = {group} AND CicloEscolar = '{year}';";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool AddPT(int id, int p1, int p2, int p3, int p4, int p5, int p6, int final, string na, string observations, string teachName, string period, int grade, string year)
        {
            bool bOk = false;
            int pt;
            try
            {
                string idPT = GetLastPTId();
                if (string.IsNullOrEmpty(idPT))
                {
                    pt = 1;
                }
                else
                {
                    pt = Convert.ToInt16(idPT);
                    pt++;
                }
                // Query para actualizar agregar calificaiones de producción de textos
                string sQry = $"INSERT INTO sisat_produccion_textos (idSisATPT, idAlumno, PEscritura, PCumplir, PRelacionar, PVocabulario, PPuntuacion, POrtografia, PFinal, Observaciones, NivelAprendizaje, Maestro, Periodo, Grado, CicloEscolar) VALUES ({pt}, {id}, {p1}, {p2}, {p3}, {p4}, {p5}, {p6}, {final}, '{observations}', '{na}', '{teachName}', '{period}', {grade}, '{year}');";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public string GetLastPTId()
        {
            string id = "";
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el último id
                using (MySqlCommand cmd = new MySqlCommand($"SELECT MAX(idSisATPT) FROM sisat_produccion_textos;", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader[0].ToString();
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public bool UpdatePT(int id, int p1, int p2, int p3, int p4, int p5, int p6, int final, string na, string observations, string period, int group, string year)
        {
            bool bOk = false;
            try
            {
                // Query para actualizar las calificaciones de producción de textos
                string sQry = $"UPDATE sisat_produccion_textos SET PEscritura = {p1}, PCumplir = {p2}, PRelacionar = {p3}, PVocabulario = {p4}, PPuntuacion = {p5}, POrtografia = {p6}, PFinal = {final}, Observaciones = '{observations}', NivelAprendizaje = '{na}' WHERE idAlumno = {id} AND Periodo = '{period}' AND Grado = {group} AND CicloEscolar = '{year}';";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool AddTL(int id, int p1, int p2, int p3, int p4, int p5, int p6, int final, string na, string observations, string teachName, string period, int grade, string year)
        {
            bool bOk = false;
            int tl;
            try
            {
                string idTL = GetLastTLId();
                if (string.IsNullOrEmpty(idTL))
                {
                    tl = 1;
                }
                else
                {
                    tl = Convert.ToInt16(idTL);
                    tl++;
                }
                // Query para agregar calificaciones de toma de lectura
                string sQry = $"INSERT INTO sisat_toma_lectura (idSisATTL, idAlumno, pFluidez, PPrecision, PAtencion, PVozAdecuada, PSeguridad, PComprension, PFinal, Observaciones, NivelAprendizaje, Maestro, Periodo, Grado, CicloEscolar) VALUES ({tl}, {id}, {p1}, {p2}, {p3}, {p4}, {p5}, {p6}, {final}, '{observations}', '{na}', '{teachName}', '{period}', {grade}, '{year}');";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public string GetLastTLId()
        {
            string id = "";
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener el último id
                using (MySqlCommand cmd = new MySqlCommand($"SELECT MAX(idSisATTL) FROM sisat_toma_lectura;", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader[0].ToString();
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public bool UpdateTL(int id, int p1, int p2, int p3, int p4, int p5, int p6, int final, string na, string observations, string period, int group, string year)
        {
            bool bOk = false;
            try
            {
                // Query para actualizar las calificaciones de toma de lectura
                string sQry = $"UPDATE sisat_toma_lectura SET PFluidez = {p1}, PPrecision = {p2}, PAtencion = {p3}, PVozAdecuada = {p4}, PSeguridad = {p5}, PComprension = {p6}, PFinal = {final}, Observaciones = '{observations}', NivelAprendizaje = '{na}' WHERE idAlumno = {id} AND Periodo = '{period}' AND Grado = {group} AND CicloEscolar = '{year}';";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public void GetCM(ref DataTable table, int id, string periodo, string year)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM sisat_calculo_mental WHERE Periodo = '{periodo}' AND idAlumno = {id} AND CicloEscolar = '{year}';"; // Obtener la información de cálculo mental

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetPT(ref DataTable table, int id, string periodo, string year)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM sisat_produccion_textos WHERE Periodo = '{periodo}' AND idAlumno = {id} AND CicloEscolar = '{year}';"; // Obtener la información de producción de textos

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetTL(ref DataTable table, int id, string periodo, string year)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM sisat_toma_lectura where Periodo = '{periodo}' and idAlumno = {id} AND CicloEscolar = '{year}';"; // Obtener la información de toma de lectura

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public int GetCountCMNE(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "Nivel esperado" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_calculo_mental WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('Nivel esperado', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public int GetCountCMED(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "En desarrollo" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_calculo_mental WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('En desarrollo', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public int GetCountCMRA(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "Requiere apoyo" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_calculo_mental WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('Requiere apoyo', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public int GetCountPTNE(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "Nivel esperado" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_produccion_textos WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('Nivel esperado', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public int GetCountPTED(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "En desarrollo" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_produccion_textos WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('En desarrollo', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public int GetCountPTRA(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "Requiere apoyo" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_produccion_textos WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('Requiere apoyo', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public int GetCountTLNE(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "Nivel esperado" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_toma_lectura WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('Nivel esperado', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public int GetCountTLED(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "En desarrollo" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_toma_lectura WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('En desarrollo', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public int GetCountTLRA(int grade, string periodo, string year)
        {
            int count = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                // Query para obtener la cantidad de "Requiere apoyo" en el salón
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) FROM sisat_toma_lectura WHERE Grado = {grade} AND Periodo = '{periodo}' AND CicloEscolar = '{year}' AND LOCATE('Requiere apoyo', NivelAprendizaje);", conMySQL))
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return count;
        }

        public void GetFinalGrade(ref DataTable table, string year, int id)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    // Obtener solamente la calificación final y periodo de evaluación de un alumno
                    string sQry = $"select CalFinal, Periodo from reporte_calificaciones where CicloEscolar = '{year}' AND idAlumno = {id};";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetFinalCM(ref DataTable table, string year, int id)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    // Obtener solamente el puntaje final y periodo de evaluación de un alumno
                    string sQry = $"select NivelAprendizaje, Periodo from sisat_calculo_mental where CicloEscolar = '{year}' AND idAlumno = {id};";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetFinalPT(ref DataTable table, string year, int id)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    // Obtener solamente el puntaje final y periodo de evaluación de un alumno
                    string sQry = $"select NivelAprendizaje, Periodo from sisat_produccion_textos where CicloEscolar = '{year}' AND idAlumno = {id};"; 

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetFinalTL(ref DataTable table, string year, int id)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}"; // Cadena de conexión
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {

                    string sQry = $"select NivelAprendizaje, Periodo from sisat_toma_lectura where CicloEscolar = '{year}' AND idAlumno = {id};";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }
    }
}

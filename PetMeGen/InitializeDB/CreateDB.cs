
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeGenNHibernate.CP.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                // USUARIOS
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                usuarioCEN.Registrarse ("danibravo@gmail.com", "123456789", "Daniel", "Bravo Garcia", "El Dani", new DateTime (1995, 11, 01), "Alicante", "Alicante", "Nuevo Usuario");
                usuarioCEN.Registrarse ("hectorsteve@gmail.com", "2143658709", "Hector", "Steve Yague", "El Hector", new DateTime (1999, 04, 21), "Alicante", "Elche", "Nuevo Usuario");
                usuarioCEN.Registrarse ("sergito19@hotmail.com", "123sube321", "Sergio", "Sebastian Aracil", "El Sergio", new DateTime (1998, 01, 19), "Alicante", "Alicante", "Nuevo Usuario");
                usuarioCEN.Registrarse ("imrubensi@gmail.com", "password", "Ruben", "Rubio Martinez", "RUBENSI", new DateTime (1997, 08, 16), "Alicante", "San Isidro", "Nuevo Usuario");

                // ADMINISTRADORES
                AdministradorCEN administradorCEN = new AdministradorCEN ();
                administradorCEN.New_ ("alexgladiator@outlook.es", "Alejandro", "Castro Valero", "El Alex", new DateTime (1997, 01, 29), "Alicante", "Albatera", 500f, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum.activo, "ttttttttty", "Penalizar comentarios obscenos");

                // CREAMOS Y PUBLICAMOS ANUNCIOS
                IList<string> animales1 = new List<string>();
                animales1.Add ("perro"); animales1.Add ("gato"); animales1.Add ("foca");
                IList<double> tarifas1 = new List<double>();
                tarifas1.Add (77.5); tarifas1.Add (45.01); tarifas1.Add (101.9);
                IList<string> animales2 = new List<string>();
                animales2.Add ("perro"); animales2.Add ("gato");
                IList<double> tarifas2 = new List<double>();
                tarifas2.Add (60); tarifas2.Add (33.336);
                UsuarioCP usuarioCP = new UsuarioCP ();
                usuarioCP.CrearAnuncio ("hectorsteve@gmail.com", new DateTime (2018, 04, 14), new DateTime (2018, 06, 21), "Avenida Indalecio Prieto", "Cuido solo perros. No me hago responsable de enfermedades.", "Elche", "Alicante", animales1, tarifas1);
                usuarioCP.CrearAnuncio ("sergito19@hotmail.com", new DateTime (2018, 04, 19), new DateTime (2018, 10, 01), "Calle Gaspar de los Cielos", "Cuido unicamente gatos y focas. No me hago responsable de enfermedades.", "Alicante", "Alicante", animales2, tarifas2);

                // HACEMOS COMENTARIOS
                AnuncioCEN anuncioCEN = new AnuncioCEN ();
                IList<AnuncioEN> p_anuncios = anuncioCEN.ReadAll (0, -1);
                usuarioCP.HacerComentario ("danibravo@gmail.com", "¿Mi madre contaria como foca?", ValoracionEnum.buena, p_anuncios [0].Id);
                usuarioCP.HacerComentario ("imrubensi@gmail.com", "Mi gata tiene que tomarse una medicacion y no cuesta nada np", ValoracionEnum.muy_buena, p_anuncios [0].Id);


                // Mirar los acentos, cambiar a UTF-16*/

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}

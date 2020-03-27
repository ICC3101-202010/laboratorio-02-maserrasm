using System;
using System.Collections;
using System.Collections.Generic;

//Laboratorio 2 POO 202010
// Manuel Serra SM
// RUT 19.957.805-7

namespace Lab2MSSM
{
    class Cancion
    {
        // Defino atributos tipo string. 
        string nombre; string album; string artista; string genero;
        // Constructor de objeto tipo cancion.
        public Cancion(string dName, string dAlbum, string dArtista, string dGenero)
        {
            nombre = dName; album = dAlbum; artista = dArtista; genero = dGenero;
        }
        // Metodo Informacion que retorna info de cancion. 
        public String Informacion()
        {
            string songInfo = "genero: " + genero + " artista: " + artista + " album: " + album + " nombre: " + nombre;
            return songInfo;
        }

        public String getName()
        {
            string songName = nombre;
            return songName;
        }

        public String getAlbum()
        {
            string songAlbum = album;
            return songAlbum;
        }

        public String getArtist()
        {
            string songArtist = artista;
            return songArtist;
        }

        public String getGen()
        {
            string songGenero = genero;
            return songGenero;
        }

    }


    class Espotifai
    {
        // Defino lista songData, donde guardare objetos de tipo cancion.
        public List<Cancion> songData;

        // Ahora el constructor.
        public Espotifai()
        {
            List<Cancion> songDataA = new List<Cancion>();
            songData = songDataA;
        }

        //Metodo agregarCancion, con el cual agrego canciones a SongData.
        public bool AgregarCancion(Cancion cancion)
        {
            string candName = cancion.getName();
            string candAlbum = cancion.getAlbum();
            string candArtist = cancion.getArtist();


            for (int i = 0; i < songData.Count; i++)
            {
                string name = songData[i].getName();
                string album = songData[i].getAlbum();
                string artist = songData[i].getArtist();

                int filter1 = string.Compare(name, candName);
                int filter2 = string.Compare(album, candAlbum);
                int filter3 = string.Compare(artist, candArtist);

                if (filter1 == 0 & filter2 == 0 & filter3 == 0) { Console.WriteLine("Error al agregar cancion"); return false; }
            }
            songData.Add(cancion);

            Console.WriteLine("Cancion agregada con exito");
            return true;

        }

        public void VerCanciones()
        {
            for (int i = 0; i < songData.Count; i++)
            {
                string songString = songData[i].Informacion();
                Console.WriteLine(songString);
            }

        }


        public List<Cancion> CancionesPorCriterio(String criterio, String valor)
        {
            List<Cancion> FilteredSongList = new List<Cancion>();
            if (criterio == "nombre")
            {
                for (int i = 0; i < songData.Count; i++)
                {
                    string name = songData[i].getName();
                    int filter = string.Compare(name, valor);
                    if (filter == 0)
                    {
                        FilteredSongList.Add(songData[i]);
                    }
                }
                if (FilteredSongList.Count == 0)
                {
                    Console.WriteLine("No hay canciones que cumplan criterio");
                }
            }

            if (criterio == "album")
            {
                for (int i = 0; i < songData.Count; i++)
                {
                    string name = songData[i].getAlbum();
                    int filter = string.Compare(name, valor);
                    if (filter == 0)
                    {
                        FilteredSongList.Add(songData[i]);
                    }
                }
                if (FilteredSongList.Count == 0)
                {
                    Console.WriteLine("No hay canciones que cumplan criterio");
                }
            }

            if (criterio == "artista")
            {
                for (int i = 0; i < songData.Count; i++)
                {
                    string name = songData[i].getArtist();
                    int filter = string.Compare(name, valor);
                    if (filter == 0)
                    {
                        FilteredSongList.Add(songData[i]);
                    }
                }
                if (FilteredSongList.Count == 0)
                {
                    Console.WriteLine("No hay canciones que cumplan criterio");
                }
            }

            if (criterio == "genero")
            {
                for (int i = 0; i < songData.Count; i++)
                {
                    string name = songData[i].getGen();
                    int filter = string.Compare(name, valor);
                    if (filter == 0)
                    {
                        FilteredSongList.Add(songData[i]);
                    }
                }
                if (FilteredSongList.Count == 0)
                {
                    Console.WriteLine("No hay canciones que cumplan criterio");
                }
            }

            return FilteredSongList;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ocupo constructor y genero gestor de canciones.
            Espotifai dataBase = new Espotifai();
            //Menu para usuarios. 
            int userChoice = 0;
            while (userChoice == 0)
            {
                Console.WriteLine("Bienvenido Usuario !!");
                Console.WriteLine("Ingrese 1 para agregar nueva cancion.");
                Console.WriteLine("Ingrese 2 para ver canciones.");
                Console.WriteLine("Ingrese 3 para ver canciones por criterio.");
                Console.WriteLine("Ingrese 4 para salir.");


                userChoice = Convert.ToInt32(Console.ReadLine());
                //Creo nueva cancion. 
                while (userChoice == 1)
                {
                    Console.WriteLine("Ingrese datos de nueva cancion");
                    Console.WriteLine("Ingrese nombre: "); string locName = Console.ReadLine();
                    Console.WriteLine("Ingrese album: "); string locAlbum = Console.ReadLine();
                    Console.WriteLine("Ingrese artista: "); string locArtist = Console.ReadLine();
                    Console.WriteLine("Ingrese genero: "); string locGen = Console.ReadLine();
                    Cancion newSong = new Cancion(locName, locAlbum, locArtist, locGen); dataBase.AgregarCancion(newSong);
                    Console.WriteLine("Ingrese 1 para agregar otra cancion, 0 para salir.");
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                //Veo canciones existentes. 
                while (userChoice == 2)
                {
                    dataBase.VerCanciones();
                    Console.WriteLine("Ingrese 0 para salir");
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }

                while (userChoice == 3)
                {
                    Console.WriteLine("Ingrese criterio: "); string crit = Console.ReadLine();
                    Console.WriteLine("Ingrese valor: "); string val = Console.ReadLine();
                    List<Cancion> orderedSongs = dataBase.CancionesPorCriterio(crit, val);

                    for (int i = 0; i < orderedSongs.Count; i++)
                    {
                        Console.WriteLine(i + orderedSongs[i].Informacion());
                    }

                    Console.WriteLine("Ingrese 0 para salir");
                    userChoice = Convert.ToInt32(Console.ReadLine());

                }
                // Opcion para terminar programa si asi lo deseo. 
                if (userChoice == 4)
                {
                    Environment.Exit(1);
                }



            }
        }

    }

}
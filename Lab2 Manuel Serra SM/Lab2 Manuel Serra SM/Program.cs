using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        //Algunas funciones auxiliares que son de utilidad. 

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
        // Defino lista songData, corresponde a la base de datos principal donde guardare todos los objetos de tipo cancion del gestor.
        public List<Cancion> songData;
        public List<Playlist> playlistData; 

        // Ahora el constructor. Construyo lista de canciones y lista de playlists.
        public Espotifai()
        {
            List<Cancion> songDataA = new List<Cancion>();
            songData = songDataA;
            List<Playlist> playlistDataD = new List<Playlist>();
            playlistData = playlistDataD;
            
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
            //Recorro songData (lista de todos los objetos tipo cancion que existen en el gestor)
            // y voy ingresando a una lista auxiliar todas las canciones que cumplan con el criterio, luego retorno aquella lista. 

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

        public bool GenerarPlaylist(string criterio, string valorCriterio, string nombrePlaylist)
        {

            //Primero veo que el criterio ingresado sea valido, en caso de que no lo sea retorno false e imprimo mensaje de error. 

            if (string.Compare("genero", criterio) == 0 | string.Compare("artista", criterio) == 0 | string.Compare("album", criterio) == 0 | string.Compare("nombre", criterio) == 0) {

                //Si criterio es valido, genero nueva playlist.

                Playlist pList = new Playlist(nombrePlaylist);

                //Recorro la lista de canciones y voy agregando a la playlist las que cumplan con el criterio. 

                //Primero recorro la lista de playlist ya existente y veo que no exista ninguna con el mismo nombre. 
                for (int k = 0; k < playlistData.Count; k++)
                {
                    string locName = playlistData[k].getName();
                    int checkName = string.Compare(locName, nombrePlaylist);
                    if (checkName == 0)
                    {
                        Console.WriteLine("No se pudo crear playlist, pues ya existe una con este nombre. ");
                        return false;
                    }
                    else { continue; }
                }

                //Habiendo checkeado lo anterior, agrego canciones a playlist segun el criterio que tenga. 

                if (criterio == "genero")
                {
                    for (int i = 0; i < songData.Count; i++)
                    {
                        string name = songData[i].getGen();
                        int filter = string.Compare(name, valorCriterio);
                        if (filter == 0)
                        {
                            pList.addSong(songData[i]);
                        }
                    }
                    if (pList.songPlayList.Count() == 0)
                    {
                        Console.WriteLine("No hay canciones que cumplan criterio, por ende no se creo playlist.");
                        return false;
                    }
                }

                if (criterio == "nombre")
                {
                    for (int i = 0; i < songData.Count; i++)
                    {
                        string name = songData[i].getName();
                        int filter = string.Compare(name, valorCriterio);
                        if (filter == 0)
                        {
                            pList.addSong(songData[i]);
                        }
                    }
                    if (pList.songPlayList.Count() == 0)
                    {
                        Console.WriteLine("No hay canciones que cumplan criterio, por ende no se creo playlist.");
                        return false;
                    }
                }

                if (criterio == "artista")
                {
                    for (int i = 0; i < songData.Count; i++)
                    {
                        string name = songData[i].getArtist();
                        int filter = string.Compare(name, valorCriterio);
                        if (filter == 0)
                        {
                            pList.addSong(songData[i]);
                        }
                    }
                    if (pList.songPlayList.Count() == 0)
                    {
                        Console.WriteLine("No hay canciones que cumplan criterio, por ende no se creo playlist.");
                        return false;
                    }
                }

                if (criterio == "album")
                {
                    for (int i = 0; i < songData.Count; i++)
                    {
                        string name = songData[i].getAlbum();
                        int filter = string.Compare(name, valorCriterio);
                        if (filter == 0)
                        {
                            pList.addSong(songData[i]);
                        }
                    }
                    if (pList.songPlayList.Count() == 0)
                    {
                        Console.WriteLine("No hay canciones que cumplan criterio, por ende no se creo playlist.");
                        return false;
                    }
                }

                playlistData.Add(pList);
                return true;



            }
            
            else { Console.WriteLine("Criterio invalido") ; return false; }


        }

        public string VerMisPlaylists()
        {

            //Recorro playlists existentes y para cada una veo informacion de canciones. Agrego esta info a un string 
            // que luego ha de ser retornado por la funcion. 

            string masterString = "";    
            for (int j = 0; j < playlistData.Count; j++)
            {
                List<Cancion> cancionesPlaylistK = playlistData[j].songPlayList;
                Console.WriteLine("Playlist Numero "); Console.WriteLine(j);
                masterString += "Playlist Numero "; masterString += j; 
                Console.WriteLine("De nombre: "); Console.WriteLine(playlistData[j].getName());

                for (int z = 0; z < cancionesPlaylistK.Count; z++) {
                    Console.WriteLine(cancionesPlaylistK[z].Informacion());
                    masterString += cancionesPlaylistK[z].Informacion();
                }

                Console.WriteLine("");
            }
            return masterString;
        }
    }

    class Playlist {

        //Declaro nombre de playlist y lista de canciones.
        
        public List<Cancion> songPlayList ;
        public string playlistName; 

        // El constructor de la playlist.
        public Playlist(string pn)
        {   
            List<Cancion> songs = new List<Cancion>();
            songPlayList = songs;
            playlistName = pn;
        }

        //Metodo para obtener nombre.
        public string getName() { return playlistName; }
        //Metodo para agregar cancion a playlist.
        public void addSong(Cancion song)
        {
            songPlayList.Add(song);
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
                // Menu principal

                //Algunas canciones de prueba. 

                //Cancion test1 = new Cancion("Los Pollitos Dicen", "Primero", "Autor 1", "Dormir"); dataBase.AgregarCancion(test1);
                //Cancion test2 = new Cancion("Los Pepitos Dicen", "Primero", "Autor 1", "Dormir"); dataBase.AgregarCancion(test2);
                //Cancion test3 = new Cancion("Los Sauces Dicen", "Primero", "Autor 1", "Dormir"); dataBase.AgregarCancion(test3);
                //Cancion test4 = new Cancion("Las guaguas cantan", "Segundo", "Autor 1", "Dormir"); dataBase.AgregarCancion(test4);
                //Cancion test5 = new Cancion("Las guaguas comen", "Segundo", "Autor 3", "Dormir"); dataBase.AgregarCancion(test5);
                //Cancion test6 = new Cancion("Los niños dicen", "Tercero", "Autor 2", "Cantar"); dataBase.AgregarCancion(test6);
                //Cancion test7 = new Cancion("Los niños comen", "Primero", "Autor 2", "Cantar"); dataBase.AgregarCancion(test7);
                //Cancion test8 = new Cancion("Los niños beben", "Cuarto", "Autor 3", "Dormir"); dataBase.AgregarCancion(test8);


                Console.WriteLine("Bienvenido Usuario !!");
                Console.WriteLine("Ingrese 1 para agregar nueva cancion.");
                Console.WriteLine("Ingrese 2 para ver canciones.");
                Console.WriteLine("Ingrese 3 para ver canciones por criterio.");
                Console.WriteLine("Ingrese 4 para crear playlist.");
                Console.WriteLine("Ingrese 5 para ver playlists.");
                Console.WriteLine("Ingrese 6 para salir.");


                userChoice = Convert.ToInt32(Console.ReadLine());
                //1. Creo nueva cancion. 
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
                //2. Veo canciones existentes. 
                while (userChoice == 2)
                {
                    dataBase.VerCanciones();
                    Console.WriteLine("Ingrese 0 para salir");
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }

                //3.Veo canciones por criterio.
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

                //Opcion para crear playlists. 

                while (userChoice == 4)
                {
                    Console.WriteLine("Ingrese criterio: "); string crit = Console.ReadLine().ToLower();
                    Console.WriteLine("Ingrese valor: "); string val = Console.ReadLine();
                    Console.WriteLine("Ingrese nombre de playlist: "); string pName = Console.ReadLine();

                    dataBase.GenerarPlaylist(crit, val, pName);

                    Console.WriteLine("Ingrese 0 para salir");
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }

                while (userChoice == 5)
                {
                    dataBase.VerMisPlaylists();
                    Console.WriteLine("Ingrese 0 para salir");
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }

                // Opcion para terminar programa si asi lo deseo. 
                if (userChoice == 6)
                {
                    Environment.Exit(1);
                }
            }
        }

    }

}
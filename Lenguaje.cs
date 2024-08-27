using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semantica;
/*
    1.Colocar el numero de linea de errores lexicos y sintacticos
    2.Cambiar la clase token por atributos publicots(get, set)
    3.Cambiar los constructores de la clase lexico usando parametros
    por default
*/

namespace Semantica
{
    public class Lenguaje : Sintaxis
    {
        public Lenguaje()
        {

        }

        public Lenguaje(string nombre) : base (nombre)
        {

        }
        //Programa  -> Librerias? Variables? Main
        public void Programa()
        {
            Librerias();
            Varibles();
            Main();
        }    
        //Librerias -> using ListaLibrerias; Librerias?
        private void Librerias(){
            match("using");
            ListaLibrerias();
            match(";");
            if (getContenido() == "using")
            {
                Librerias();
            }
        }
        //ListaLibrerias -> identificador (.ListaLibrerias)?
        private void ListaLibrerias()
        {
            match(Tipos.Identificador);
            if(getContenido() == ".")
            {
                match(".");
                ListaLibrerias();
            }                
        }
        //Variables -> tipo_dato Lista_identificadores; Variables?

        /* 
         
        ListaIdentificadores -> identificador (,ListaIdentificadores)?
        BloqueInstrucciones -> { listaIntrucciones? }
        ListaInstrucciones -> Instruccion ListaInstrucciones?

        Instruccion -> Console | If | While | do | For | Asignacion
        Asignacion -> Identificador = Expresion;

        If -> if (Condicion) bloqueInstrucciones | instruccion
            (else bloqueInstrucciones | instruccion)?

        Condicion -> Expresion operadorRelacional Expresion

        While -> while(Condicion) bloqueInstrucciones | instruccion
        Do -> do 
                bloqueInstrucciones | intruccion 
            while(Condicion);
        For -> for(Asignacion Condicion; Incremento) 
            BloqueInstrucciones | Intruccion 
        Incremento -> Identificador ++ | --

        Console -> Console.(WriteLine|Write) (cadena); |
                Console.(Read | ReadLine) ();

        Main      -> static void Main(string[] args) BloqueInstrucciones 

        Expresion -> Termino MasTermino
        MasTermino -> (OperadorTermino Termino)?
        Termino -> Factor PorFactor
        PorFactor -> (OperadorFactor Factor)?
        Factor -> numero | identificador | (Expresion)
        */
    }
}
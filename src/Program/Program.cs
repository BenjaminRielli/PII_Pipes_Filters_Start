using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"C:\Users\Benjamin Rielli\Escritorio\UCU\programacion 2\TareasProgramacion\EjercicioPipes&filters\PII_Pipes_Filters_Start\src\Program\beer.jpg");
            IPicture picture2;
            IPicture picture3;

            PipeNull Null = new PipeNull();
            Null.Send(picture);

            FilterNegative filtroNegativo = new FilterNegative();
            picture2 = filtroNegativo.Filter(picture);                           //filtro negativo   
            PipeSerial pipeSerial2 = new PipeSerial(filtroNegativo, Null);  
            pipeSerial2.Send(picture2);   
               
            FilterGreyscale filtroEscalaGris = new FilterGreyscale(); 
            picture3 = filtroEscalaGris.Filter(picture2);                         //filtro escala grises
            PipeSerial pipeSerial1 = new PipeSerial(filtroEscalaGris, pipeSerial2);
            pipeSerial1.Send(picture3);

            provider.SavePicture(picture3, @"C:\Users\Benjamin Rielli\Escritorio\UCU\programacion 2\TareasProgramacion\EjercicioPipes&filters\PII_Pipes_Filters_Start\src\Program\filtroBeer.jpg");
            


        }
    }
}

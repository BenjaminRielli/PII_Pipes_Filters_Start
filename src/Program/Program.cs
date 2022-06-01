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
            PictureProvider p = new PictureProvider();
            IPicture picture2 = p.GetPicture(@"C:\Users\Benjamin Rielli\Escritorio\UCU\programacion 2\TareasProgramacion\EjercicioPipes&filters\PII_Pipes_Filters_Start\src\Program\beer.jpg");
            
            PipeNull Null = new PipeNull();
            Null.Send(picture2);

            FilterNegative filtroNegativo = new FilterNegative();
            picture2 = filtroNegativo.Filter(picture2);                           //filtro negativo   
            PipeSerial pipeSerial2 = new PipeSerial(filtroNegativo, Null);  
            pipeSerial2.Send(picture2);   
               
            FilterGreyscale filtroEscalaGris = new FilterGreyscale(); 
            picture = filtroEscalaGris.Filter(picture);                         //filtro escala grises
            PipeSerial pipeSerial1 = new PipeSerial(filtroEscalaGris, pipeSerial2);
            pipeSerial1.Send(picture);

            //pipeSerial1.Send(picture);
            //pipeSerial2.Send(picture);
            //Null.Send(picture);

            provider.SavePicture(picture, @"C:\Users\Benjamin Rielli\Escritorio\UCU\programacion 2\TareasProgramacion\EjercicioPipes&filters\PII_Pipes_Filters_Start\src\Program\beer.jpg");
            p.SavePicture(picture2, @"C:\Users\Benjamin Rielli\Escritorio\UCU\programacion 2\TareasProgramacion\EjercicioPipes&filters\PII_Pipes_Filters_Start\src\Program\beer.jpg");


        }
    }
}

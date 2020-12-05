using System;

namespace PRIMERA_RED_NEURONAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Neurona p = new Neurona(2, 1f);
            Random r = new Random();
            bool sw = false;
            while (!sw)
            {
                sw = true;
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("paso1 :" + p.Pesos[0]);
                Console.WriteLine("paso2 :" + p.Pesos[1]);
                Console.WriteLine("Error :" + p.Umbral);
                Console.WriteLine("E1:1 E2:1 :" + p.Salida(new float[2] { 1f, 1f }));
                Console.WriteLine("E1:1 E2:0 :" + p.Salida(new float[2] { 1f, 0f }));
                Console.WriteLine("E1:0 E2:1 :" + p.Salida(new float[2] { 0f, 1f }));
                Console.WriteLine("E1:0 E2:0 :" + p.Salida(new float[2] { 0f, 0f }));
                if (p.Salida(new float[2] { 1f, 1f }) != 1)
                {
                   p.Apreder(new float[2] { 1f, 1f }, 1);
                    sw = false;

                }
                if (p.Salida(new float[2] { 1f, 0f }) != 0)
                {
                    p.Apreder(new float[2] { 1f, 0f }, 0);

                    sw = false;
                }
                if (p.Salida(new float[2] { 0f, 1f }) != 0)
                {
                    p.Apreder(new float[2] { 0f, 1f }, 0);
                    sw = false;
                }
                if (p.Salida(new float[2] { 0f, 0f }) != 0)
                {
                    p.Apreder(new float[2] { 0f, 0f }, 0);
                    sw = false;
                }
                Console.ReadKey();
            }
        }
        
       /* float Neurona(float entrada1, float entrada2, float paso1, float paso2, float unmbral)
        {
            return unmbral + entrada1 * paso1 + entrada2 * paso2;
        }
        float funcion(float d)
        {
            return d > 0 ? 1 : 0;
        }*/
    }
    public class Neurona
    {
        float[] PesoAntetio;
        float UmbrealAnterior;
        //peso=pesoanterio* tasa apredisaje*error*entrada
        public float[] Pesos;
        public float Umbral;
        public float TasaDeApredisaje = 0.3f;
        public Neurona(int NEntrada, float tasaDeApredisaje=0.3f)
        {
            TasaDeApredisaje = tasaDeApredisaje;
            Pesos = new float[NEntrada];
            PesoAntetio = new float[NEntrada];
            Apreder();
        }
        public void Apreder()
        {
            Random r = new Random();
            for (int i = 0; i < PesoAntetio.Length; i++)
            {
                PesoAntetio[i] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
            }
            UmbrealAnterior = Convert.ToSingle(r.NextDouble() - r.NextDouble());
            Pesos = PesoAntetio;
            Umbral= UmbrealAnterior;
        }
        public void Apreder(float[] entrada, float salidaESperda)
        {
            
                float error = salidaESperda - Salida(entrada);
                for(int i=0; i<Pesos.Length;i++)
                {
                    Pesos[i] = PesoAntetio[i] + TasaDeApredisaje * error * entrada[i];
                }
                Umbral = UmbrealAnterior + TasaDeApredisaje * error;
                PesoAntetio = Pesos;
                UmbrealAnterior = Umbral;  
        }
        public float Salida(float[] entrada)
        {
            return Signomi(neurona(entrada));
        }
        float neurona(float[] entradas)
        {
            float sum = 0;
            for (int i = 0; i < Pesos.Length; i++)
            {
                sum += entradas[i] * Pesos[i];
            }
            sum += Umbral;
            return sum;
        }
        float Signomi(float d)
        {
            return d > 0 ? 1 : 0;
        }
    }
}

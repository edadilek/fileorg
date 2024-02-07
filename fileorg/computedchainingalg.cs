using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileorg
{

    class computedchainingalg
    {
        public void computedchaining()
        {
            //örnek veriler
            int[] array = { 27, 18, 29, 28, 39, 13, 16, 38, 53 };
            int hashKey = 11;
            int[] table = new int[hashKey];
            int[] noftable = new int[hashKey];
            bool[] isValuePlaced = new bool[hashKey]; //değer kendi yerine mi yerleşmiş yoksa kendi yeri dolu diye ilerleyerek mi gelmiş kontrolü
            int nof;

            for (int i = 0; i < array.Length; i++)
            {
                int primaryIndex = array[i] % hashKey;   // 5                                    


                if (table[primaryIndex] == 0) //tabloda 5 kısmı boşsa
                {
                    table[primaryIndex] = array[i];
                    noftable[primaryIndex] = 0; 
                    isValuePlaced[primaryIndex] = true; //kendi yerine yerleşti true yaptı
                }
                else if (table[primaryIndex] != 0 && isValuePlaced[primaryIndex] == true && noftable[primaryIndex] == 0) //tabloda 5 kısmı dolu ve kendi yerine yerleşen biri var
                {
                    int j;
                    int Index = table[primaryIndex] / 11 % hashKey;
                    bool valuePlaced = false;
                    if (noftable[primaryIndex] != 0)
                    {

                        int k = primaryIndex + (noftable[primaryIndex] * Index); //16 k=9
                        int zortIndex2 = table[k] / 11 % hashKey;
                        for (j = 1; j < 10 && !valuePlaced; j++)
                        {
                            nof = ((k + (j * zortIndex2))) % 11; //nof değeri 9 diyelim 5 dolu

                            if (table[nof] == 0) //9 yeri boşsa
                            {
                                table[nof] = array[i];
                                noftable[k] = j; 
                                isValuePlaced[nof] = false;
                                valuePlaced = true;
                            }

                        }
                    }

                    for (j = 1; j < 10 && !valuePlaced; j++)
                    {
                        nof = ((primaryIndex + (j * Index))) % 11; //nof değeri 9 diyelim 5 dolu

                        if (table[nof] == 0) //9 yeri boşsa
                        {
                            table[nof] = array[i];
                            noftable[primaryIndex] = j; 
                            isValuePlaced[nof] = false;
                            valuePlaced = true;
                        }

                    }
                }


                else if (isValuePlaced[primaryIndex] != true && table[primaryIndex] != 0)
                {
                    int m = table[primaryIndex] % hashKey;
                    int n = (table[m] / 11) % hashKey;
                    int nextIndex = ((m + ((noftable[m] + 1) * n))) % 11;
                    if (table[nextIndex] == 0)
                    {
                        noftable[m]++;
                        int elm = table[nextIndex];
                        table[nextIndex] = table[primaryIndex];
                        table[primaryIndex] = array[i];

                    }

                }
            }

            // Display the results
            Console.WriteLine("COMPUTED CHAINING");
            Console.WriteLine("Address\tValue\tnof");

            for (int i = 0; i < hashKey; i++)
            {
                Console.WriteLine($"{i}\t{table[i]}\t{noftable[i]}");
            }
        }
    }
}





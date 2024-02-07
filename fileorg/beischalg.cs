using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace fileorg
{
    class beischalg
    {

        public void PlaceIntoBeischArray(int[] array, int hashKey)
        {
            int[] table = new int[hashKey]; //değerlerin tutulduğu dizi
            string[] refersTo = new string[hashKey]; //refer değerlerinin tutulduğu dizi
            int homeAddress;
            bool flag = true;

            for (int i = 0; i < array.Length; i++)
            {
                homeAddress = array[i] % hashKey; //modunu alıp home adresi belirlenir

                if (table[homeAddress] == 0) //home adresi bozsa direkt yerleşir
                {
                    table[homeAddress] = array[i];
                }
                else if (table[homeAddress] != 0 && refersTo[homeAddress] == null) //home adresi doluysa ve refer ettiği bir yer yoksa
                {
                    if (flag) //alttan mı yerleşecek üstten mi kontrolü
                    {
                        for (int j = table.Length - 1; j >= 0; j--) //alttan
                        {
                            if (table[j] == 0) //altta boş bulduğu yere yerleşir
                            {
                                table[j] = array[i];
                                refersTo[homeAddress] = j.ToString();
                                break;
                            }
                        }
                        flag = false;
                    }
                    else
                    {
                        for (int j = 0; j < table.Length; j++) //üstten
                        {
                            if (table[j] == 0) //üstte boş bulduğu yere yerleşir
                            {
                                table[j] = array[i];
                                refersTo[homeAddress] = j.ToString();
                                break;
                            }
                        }
                        flag = true;
                    }
                }
                else if (table[homeAddress] != 0 && refersTo[homeAddress] != null) //home adresi doluysa ve refer ettiği yer varsa
                {
                    if (flag) //alttan mı üstten mi
                    {
                        if ((table[homeAddress] % hashKey) != homeAddress) //eğer home adresinde oraya ait olmayan bir sayı varsa
                        {
                            int e = -1;
                            for (int j = table.Length - 1; j >= 0; j--)
                            {
                                if (table[j] == 0) //alttan boş yer bul
                                {
                                    table[j] = array[i];
                                    e = j;
                                    break;
                                }
                                flag = false;
                            }

                            int k = homeAddress;
                            while (refersTo[k] != null) //referleri takip ederek bir yeri refer etmeyen refer to = null olan son değer bulunur
                            {
                                k = int.Parse(refersTo[k]);
                            }
                            refersTo[k] = e.ToString();
                        }
                        else
                        {
                            for (int j = table.Length - 1; j >= 0; j--)
                            {
                                if (table[j] == 0)
                                {
                                    table[j] = array[i];
                                    int tempAddress = int.Parse(refersTo[homeAddress]);
                                    refersTo[homeAddress] = j.ToString();
                                    refersTo[j] = tempAddress.ToString();
                                    break;
                                }
                            }
                            flag = false;

                        }


                    }

                    else
                    {
                        if (table[homeAddress] % hashKey != homeAddress) //eğer home adresinde oraya ait olmayan bir sayı varsa aynı işlemler yapılır
                        {
                            int e = -1;
                            for (int j = table.Length - 1; j >= 0; j--)
                            {
                                if (table[j] == 0)
                                {
                                    table[j] = array[i];
                                    e = j;
                                    break;

                                }
                                flag = true;

                            }
                            int k = homeAddress;
                            while (refersTo[k] != null)
                            {
                                k = int.Parse(refersTo[k]);
                            }

                            refersTo[k] = e.ToString();


                        }
                        else
                        {
                            for (int j = 0; j < table.Length; j++)
                            {
                                if (table[j] == 0)
                                {
                                    table[j] = array[i];
                                    int tempAddress = int.Parse(refersTo[homeAddress]);
                                    refersTo[homeAddress] = j.ToString();
                                    refersTo[j] = tempAddress.ToString();
                                    break;
                                }
                            }
                            flag = true;

                        }




                    }
                }


            }
            
            

            //tablonun yazdırılması
            Console.WriteLine("**BEISCH**");
            Console.WriteLine("Index\tKeys\tLinks");
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"{i}\t{table[i]}\t{refersTo[i]}");
            }
            


        }
        

    }
}





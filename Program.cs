using System;
class Program{
    public static void Main(string[] args){
        bool[] jx = new bool[]{false,false,false,false,false,false,false,false,false};
        bool[] jy = new bool[]{false,false,false,false,false,false,false,false,false};
        string[] tabuleiro = new string[]{"-","-","-","-","-","-","-","-","-"};
        bool winx=false;
        bool winy=false;
        while(!winx||!winy){
            int jogada;
            PrintTable(tabuleiro);
            Console.WriteLine();

            Console.WriteLine("X, efetue sua jogada.");
            try{
            jogada = int.Parse(Console.ReadLine());
            }
            catch(Exception e){
                throw new Exception("Jogo encerrado, mexer dps nisso");
            }
            jx[jogada] = true;



            Console.WriteLine("Y, efetue sua jogada.");
            Console.ReadLine();
        }

    }
    public static void PrintTable(string[] tabuleiro){
            for (int i = 0; i < tabuleiro.Length; i++){
                if(i%3==0){
                    Console.WriteLine("");
                }
                Console.Write("|"+tabuleiro[i]);
            }
    }
    public static bool IsWinner(bool[] var){
               if(
            var[0]&&var[1]&&var[3]||
            var[4]&&var[5]&&var[6]||
            var[7]&&var[8]&&var[9]||
            
            var[0]&&var[4]&&var[7]||
            var[1]&&var[5]&&var[8]||
            var[3]&&var[6]&&var[9]||
            
            var[0]&&var[5]&&var[9]||
            var[3]&&var[5]&&var[7]
            ){

            return true;
        }
        else{
            return false;
        }
    }
}
using System;
class Program{
    private static string[] tabuleiro = new string[]{"0","1","2","3","4","5","6","7","8"};

    public static void Main(string[] args){
        bool[] jx = new bool[]{false,false,false,false,false,false,false,false,false};
        bool[] jy = new bool[]{false,false,false,false,false,false,false,false,false};
        bool winx=false;
        bool winy=false;
        while(!winx||!winy){
            int jogada;
            PrintTable(tabuleiro);
            if(IsWinner(jy)){
                winy=true;
                Console.WriteLine("O ganhador é 'Y'");
                break;
            }
            else{

            Console.WriteLine("X, efetue sua jogada.");
            try{
            jogada = int.Parse(Console.ReadLine());
            }
            catch(Exception e){
                throw new Exception("Jogo encerrado, mexer dps nisso");
            }
            ColocaPonto(jogada,jx,jy,"X");
            
            PrintTable(tabuleiro);
            if(IsWinner(jx)){
                winx=true;
                Console.WriteLine("O ganhador é 'X'");
                break;
            }
            else{
            Console.WriteLine("Y, efetue sua jogada.");
            try{
            jogada = int.Parse(Console.ReadLine());
            }
            catch(Exception e){
                throw new Exception("Jogo encerrado, mexer dps nisso");
            }
            ColocaPonto(jogada,jy,jx,"Y");
                }
            }
        }

    }
    public static void PrintTable(string[] tabuleiro){
            for (int i = 0; i < tabuleiro.Length; i++){
                if(i%3==0){
                    Console.WriteLine("");
                }
                Console.Write("|"+tabuleiro[i]);
            }
            Console.WriteLine();
    }


    public static void ColocaPonto(int position,bool[] jogador,bool[] adversario,string desenho){
        if(jogador[position]||adversario[position]||position<0||position>8){
            Console.WriteLine("A posição no tabuleiro esta ocupada por outra peça ou a jogada é inválida, jogue denovo");
            try{
            position = int.Parse(Console.ReadLine());
            }
            catch(Exception e){
                throw new Exception("Jogo encerrado, mexer dps nisso");
            }
            ColocaPonto(position,jogador,adversario,desenho);
        }
        else{
            jogador[position]=true;
            tabuleiro[position]=desenho;
        }
    }


    public static bool IsWinner(bool[] var){
               if (
    var[0] && var[1] && var[2] ||
    var[3] && var[4] && var[5] ||
    var[6] && var[7] && var[8] ||
    
    var[0] && var[3] && var[6] ||
    var[1] && var[4] && var[7] ||
    var[2] && var[5] && var[8] ||
    
    var[0] && var[4] && var[8] ||
    var[2] && var[4] && var[6]
){

            return true;
        }
        else{
            return false;
        }
    }
}
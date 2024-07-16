using System;
class Program{
    
    private static string[] tabuleiro = new string[]{"0","1","2","3","4","5","6","7","8"};

    public static void Main(string[] args){
        bool[] jx = new bool[]{false,false,false,false,false,false,false,false,false};
        bool[] jy = new bool[]{false,false,false,false,false,false,false,false,false};
        bool winx=false;
        bool winy=false;
        int ponto2x=-1,ponto3x=-1,deletarx=-1;
        int ponto2y=-1,ponto3y=-1,deletary=-1;
        while(!winx||!winy){
            int jogada;
            PrintTable(tabuleiro);
            if(IsWinner(jy)){
                winy=true;
                Console.WriteLine("O ganhador é 'Y'");
                break;
            }
            else{
            
            System.Console.WriteLine("X, efetue sua jogada");
            jogada = PegaNumero();
            ColocaPonto(jogada,jx,jy,"X");
            PrintTable(tabuleiro);
            if(IsWinner(jx)){
                winx=true;
                Console.WriteLine("O ganhador é 'X'");
                break;
            }
            else{
            PassaEtapa(jogada,ref ponto2x,ref ponto3x,ref deletarx, jx);

            Console.WriteLine("Y, efetue sua jogada.");
            jogada=PegaNumero();
            PassaEtapa(jogada,ref ponto2y,ref ponto3y,ref deletary, jy);
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
            position = PegaNumero();
            ColocaPonto(position,jogador,adversario,desenho);
        }
        else{
            jogador[position]=true;
            tabuleiro[position]=desenho;
        }
    }


    public static void PassaEtapa(int passo1jogada,ref int passo2,ref int passo3,ref int deletar,bool[] jogador){
        deletar=passo3;
        passo3=passo2;
        passo2=passo1jogada;
        if(deletar!=-1){
        jogador[deletar]=false;
        tabuleiro[deletar]=deletar.ToString();
        }
    }
    public static int PegaNumero(){
        try{
            int temp = int.Parse(Console.ReadLine());
            if(temp>8||temp<0){
                return PegaNumero();
            }else{
                return temp;
            }
            }
            catch(Exception){
                return PegaNumero();
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
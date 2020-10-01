using System;
using System.IO;

public class Conta{
	public int index;
	public float valor;
	public int dia, mes, ano;

	public void printarContas(string[] contas){
		int tamanho = contas.Length - 1;
		string aux2;
		char aux3;
		for(int i = 0; i < tamanho; i++){
			aux2 = contas[i];
			aux3 = aux2[0];
			if(i%5 == 0){
				Console.WriteLine ("------------------------------");
				Console.WriteLine("Índice da conta: "+ contas[i]);
			}else if(aux3 == 'd'){
				contas[i] = contas[i];
				Console.WriteLine("Vencimento da conta: "+ contas[i].TrimStart('d')+"/"+contas[(i+1)]+"/"+contas[(i+2)]);
				i +=2;
			}else{
				Console.WriteLine("Valor da conta: "+ contas[i]);
			}
		}
		Console.WriteLine ("------------------------------");
	}

	public void gravarConta(string[] contas){
		StreamWriter escrita = new StreamWriter("Contas.txt");
		for(int i = 0; i < contas.Length; i++){
			escrita.WriteLine(contas[i]);
		}
		escrita.Close();
	}

	public void deletarConta(string[] contas, int indice){
		StreamWriter escrita = new StreamWriter("Contas.txt");
    	string aux = indice.ToString();
		for(int i = 0; i < contas.Length; i++){
			if((contas[i] == aux)&&(i % 5 == 0)){
				Console.WriteLine("Conta de indice: "+aux+" apagada.");
				i+=4;
			}
			else {
			escrita.WriteLine(contas[i]);
			}
		}
		escrita.Close();
	}

	public string[] registrarConta(Conta cont){
		Console.WriteLine("Escolha um indice pra sua conta (apenas números)");
		cont.index = int.Parse(Console.ReadLine());
		Console.WriteLine("Qual o valor da conta a pagar? (apenas números)");
		cont.valor = float.Parse(Console.ReadLine());
		Console.WriteLine("Qual o dia de vencimento da sua conta? (apenas números)");
		cont.dia = int.Parse(Console.ReadLine());
		Console.WriteLine("Qual o mês de vencimento da sua conta? (apenas números)");
		cont.mes = int.Parse(Console.ReadLine());
		Console.WriteLine("Qual o ano de vencimento da sua conta? (apenas números)");
		cont.ano = int.Parse(Console.ReadLine());
		string[] contas = {cont.index.ToString(), cont.valor.ToString(), ("d" + cont.dia.ToString()), cont.mes.ToString(), cont.ano.ToString()};
		return contas;
	}

	public string[] lerContas(){
    	string[] contasE = File.ReadAllLines("Contas.txt");
    	return contasE;
  	}

	public void menuConta(Conta cont){
		int opconta = 0;
    	while(opconta!= 4){
	      Console.WriteLine ("------------------------------");
	      Console.WriteLine ("1 - REGISTRAR NOVA CONTA");
	      Console.WriteLine ("2 - CONSULTAR CONTAS");
	      Console.WriteLine ("3 - DELETAR CONTA");
	      Console.WriteLine ("4 - SAIR");
	      Console.WriteLine ("------------------------------");
	      opconta = int.Parse(Console.ReadLine());
	      switch(opconta){
	        case 1:
	        Console.Clear();
	        if (File.Exists("Contas.txt")){
	        	string[] contasExist = lerContas();
	        	string[] novaConta = registrarConta(cont);
	        	var novoregistro = new string[contasExist.Length + novaConta.Length];
	        	contasExist.CopyTo(novoregistro, 0);
				novaConta.CopyTo(novoregistro, contasExist.Length);
	        	gravarConta(novoregistro);
	        }
	        else {
	        	string[] novaConta2 = registrarConta(cont);
	        	gravarConta(novaConta2);
	        }
	        Console.Clear();
	        Console.WriteLine("Conta registrada com sucesso!");
	        break;
	        case 2:
	        Console.Clear();
	        if(File.Exists("Contas.txt")){
      			string[] contasE = lerContas();
      			printarContas(contasE);
    		}
    		else{
    			Console.WriteLine("Não existem contas pendentes!");
    		}
	        break;
	        case 3:
	        Console.Clear();
	       if(File.Exists("Contas.txt")){
      			string[] contasEx = lerContas();
      			printarContas(contasEx);
      			Console.WriteLine("Qual o índice da conta que você deseja deletar?");
      			int indice = int.Parse(Console.ReadLine());
      			deletarConta(contasEx, indice);
    		}
    		else{
    			Console.WriteLine("Não existem contas pendentes!");
    		}
	        break;
	        case 4:
	        Console.Clear();
	        break;
	        default:
	        Console.Clear();
	        Console.WriteLine("Opção inválida, tente novamente:");
	        break;
	      }
		}
	}
}
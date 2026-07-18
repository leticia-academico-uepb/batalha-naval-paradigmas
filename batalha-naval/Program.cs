using System;
using Gtk;

class Program
{
    // CÓDIGO TESTE DO GTK - SIMULAÇÃO FEITA POR IA
    static void Main()
    {
        // Inicializa o ecossistema gráfico do GTK
        Application.Init();

        // 1. Configuração da Janela Principal
        Window janela = new Window("Batalha Naval - Almirante C#");
        janela.SetDefaultSize(600, 650);
        janela.SetPosition(WindowPosition.Center);
        janela.Resizable = false;
        
        janela.DeleteEvent += (o, args) => Application.Quit();

        // 2. Container Principal Vertical (Para colocar o título em cima e o grid embaixo)
        VBox layoutPrincipal = new VBox(false, 10);
        layoutPrincipal.BorderWidth = 15;

        // 3. Título do Jogo
        Label titulo = new Label("<b>⚓ BATALHA NAVAL ⚓</b>");
        titulo.UseMarkup = true; // Permite usar tags tipo HTML para formatação
        layoutPrincipal.PackStart(titulo, false, false, 5);

        Label subTitulo = new Label("Clique nas coordenadas para disparar os torpedos");
        layoutPrincipal.PackStart(subTitulo, false, false, 0);

        // 4. O Tabuleiro (Grid 10x10 criado puramente por lógica/código)
        Grid tabuleiro = new Grid();
        tabuleiro.RowSpacing = 4;
        tabuleiro.ColumnSpacing = 4;
        tabuleiro.RowHomogeneous = true;    // Garante que todas as linhas tenham o mesmo tamanho
        tabuleiro.ColumnHomogeneous = true; // Garante que todas as colunas tenham o mesmo tamanho

        int tamanhoTabuleiro = 10;

        for (int linha = 0; linha < tamanhoTabuleiro; linha++)
        {
            for (int coluna = 0; coluna < tamanhoTabuleiro; coluna++)
            {
                // Criamos o botão representando a água
                Button blocoAgua = new Button(" 🌊");
                
                // Salvamos as coordenadas locais para o escopo do evento de clique
                int l = linha;
                int c = coluna;

                // Evento de clique: Lógica separada por botão de forma dinâmica
                blocoAgua.Clicked += (sender, args) => {
                    Button botaoClicado = (Button)sender;
                    
                    // Mostra o log de coordenadas direto no terminal de suporte
                    Console.WriteLine($"[SISTEMA DE TIRO] Coordenada disparada: Linha {l}, Coluna {c}");
                    
                    // Simulação visual de acerto/erro alterando o texto do botão clicado
                    botaoClicado.Label = "💥"; 
                    botaoClicado.Sensitive = false; // Desativa o botão para não atirar no mesmo lugar
                };

                // Adiciona o botão criado na posição exata (coluna, linha, largura, altura)
                tabuleiro.Attach(blocoAgua, coluna, linha, 1, 1);
            }
        }

        // Adiciona o tabuleiro dentro do layout vertical principal
        layoutPrincipal.PackStart(tabuleiro, true, true, 10);

        // Adiciona o layout completo dentro da janela e renderiza tudo
        janela.Add(layoutPrincipal);
        janela.ShowAll();

        // Inicia a escuta de eventos gráficos
        Application.Run();
    }
}
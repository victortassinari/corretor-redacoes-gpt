<script>
  import { writable } from 'svelte/store';
  import { marked } from 'marked'; 

  let essayTitle = 'desigualdade social';  
  let essayTheme = 'desigualdade social em povos negros na índia'; 
  let essayText = `A desigualdade social é um dos problemas mais graves enfrentados pelo Brasil, manifestando-se de diversas formas, desde a disparidade de renda até o acesso desigual a oportunidades. Nesse contexto, a educação emerge como um dos principais instrumentos de combate a essas desigualdades, pois tem o potencial de transformar a realidade de indivíduos e comunidades inteira.

Primeiramente, é fundamental entender que a educação de qualidade oferece às pessoas as ferramentas necessárias para o desenvolvimento pessoal e profissional. Indivíduos com maior nível de escolaridade tendem a acessar melhores oportunidades de emprego e alcançar maior estabilidade financeira, o que contribui para a redução das disparidade econômicas. Além disso, a educação promove o pensamento crítico, permitindo que os cidadãos participem ativamente da sociedade e lutem pelos seus direito.

Ademais, a educação é um fator crucial para a mobilidade social. Em um país onde o destino de muitos ainda é determinado pelas condições sociais em que nasceram, o acesso a uma educação de qualidade pode ser o diferencial entre perpetuar um ciclo de pobreza ou quebra-lo. Políticas públicas que garantam o acesso universal à educação, desde a infância até a formação superior, são essenciais para que esse ciclo seja interrompido.

Entretanto, é importante destaca que o simples acesso à educação não é suficiente. É preciso garantir que essa educação seja de qualidade, com professores capacitados, infraestrutura adequada e metodologias de ensino que respeitem as diversidades culturais e regionais do Brasil. A qualidade da educação é tão importante quanto a quantidade, pois uma educação precária pode, ao invés de reduzir, perpetuar as desigualdades sociais.

Por fim, é necessário que o Estado assume um papel ativo na promoção de políticas educacionais inclusivas, que alcancem todas as camadas da população, especialmente as mais vulneráveis. Investir em educação é investir no futuro do país, pois um povo educado é capaz de construir uma sociedade mais justa, equitativa e com menos desigualdade.

Em suma, a educação desempenha um papel crucial no combate à desigualdade social no Brasil. Para que o país possa avançar nessa questão, é fundamental que sejam implementadas políticas públicas que garantam não apenas o acesso, mas também a qualidade do ensino, de modo a proporcionar oportunidades iguais para todos os cidadãos`;
 
  let response = writable('');
  let isLoading = writable(false);
  let correctedEssayContainer; 
  const API_URL = import.meta.env.VITE_API_URL;
  console.log('API_URL',API_URL)

  const correctEssay = async () => {
    isLoading.set(true);
    response.set('');


    
    const responseStream = await fetch(`${API_URL}/essay-text/correct`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'accept': 'text/html'
      },
      body: JSON.stringify({
        text: essayText,
        title: essayTitle, 
        theme: essayTheme
      })
    });

    const reader = responseStream.body.getReader();
    const decoder = new TextDecoder('utf-8');

    let markdown = '';
    while (true) {
      const { done, value } = await reader.read();
      if (done) break;
      markdown += decoder.decode(value, { stream: true });

      response.set(marked(markdown));
    }

    isLoading.set(false);
  };
</script>

<!-- Navbar -->
<nav class="bg-gray-900 p-4">
  <div class="container mx-auto flex justify-between items-center">
    <a href="/" class="text-white text-lg font-semibold">ENEM Essay Correction</a>
  </div>
</nav>

<!-- Main Content -->
<div class="container mx-auto mt-10 text-gray-200">
  {#if !$response}
  <h2 class="text-3xl font-bold mb-6">Corrija sua Redação do ENEM</h2>
  
  <form class="space-y-6 bg-gray-800 p-6 rounded-lg shadow-lg" on:submit|preventDefault={correctEssay}>
    <div>
      <label class="block text-sm font-medium" for="essay-title">Título:</label>
      <input type="text" id="essay-title" class="block w-full mt-1 p-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm" bind:value={essayTitle} placeholder="Digite o título da redação...">
    </div>

    <div>
      <label class="block text-sm font-medium" for="essay-theme">Tema:</label>
      <input type="text" id="essay-theme" class="block w-full mt-1 p-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm" bind:value={essayTheme} placeholder="Digite o tema da redação...">
    </div>

    <div>
      <label class="block text-sm font-medium" for="essay-text">Redação:</label>
      <textarea id="essay-text" rows="10" class="block w-full mt-1 p-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm" bind:value={essayText} placeholder="Escreva sua redação aqui..."></textarea>
    </div>
    
    <div>
      <button class="px-4 py-2 border-2 border-blue-500 text-blue-500 font-semibold rounded-none hover:bg-blue-500 hover:text-white transition-colors duration-200" type="submit" disabled={$isLoading}>
        {#if $isLoading}
          Processando...
        {:else}
          Corrigir Redação
        {/if}
      </button>
    </div>
  </form>
    {/if}
  <!-- Condicional de visibilidade para a área da resposta -->
  {#if $response}
    <div class="mt-10 flex justify-center">
      <div class="bg-white text-black p-8 shadow-lg w-full max-w-[210mm] min-h-[297mm]">
        <div class="prose" bind:this={correctedEssayContainer} bind:innerHTML={$response} contenteditable="false"></div>
      </div>
    </div>
  {/if}
</div>

<style>
  .prose {
    max-width: none;
  }
  .text-black {
    color: #000;
  }
</style>
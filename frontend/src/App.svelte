<script>
  import { Router, Route } from 'svelte-routing';
  import EssayCorrection from './routes/EssayCorrection.svelte';
</script>

<Router>
  <Route path="/" component={EssayCorrection} />
</Router>
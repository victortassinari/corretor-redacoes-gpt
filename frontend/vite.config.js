import { defineConfig } from "vite";
import { svelte } from "@sveltejs/vite-plugin-svelte";

export default defineConfig({
  plugins: [svelte()],
  css: {
    preprocessorOptions: {
      css: {
        additionalData: `
          @import "tailwindcss/base";
          @import "tailwindcss/components";
          @import "tailwindcss/utilities";
        `,
      },
    },
  },
});

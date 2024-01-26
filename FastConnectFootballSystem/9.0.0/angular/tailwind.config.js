/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {
      colors: {
        foreground: 'hsl(var(--foreground))',
        background: 'hsl(var(--background))',
        brand: {
          DEFAULT: '#EFEFEF',
          foreground: '#111518',
        },
        // brand: {
        //   200: '#b981ff',
        //   500: '#7303FF',
        //   600: '#6803e6',
        // },
        primary: {
          200: '#c0e6ec',
          500: '#00b2be',
          600: '#00a0ab',
          DEFAULT: 'hsl(var(--primary))',
          foreground: 'hsl(var(--primary-foreground))',
        },
        destructive: {
          DEFAULT: 'hsl(var(--destructive))',
          foreground: 'hsl(var(--destructive-foreground))',
        },
        secondary: {
          DEFAULT: 'hsl(var(--secondary))',
          foreground: 'hsl(var(--secondary-foreground))',
        },
        muted: {
          DEFAULT: 'hsl(var(--muted))',
          foreground: 'hsl(var(--muted-foreground))',
        },
        accent: {
          DEFAULT: 'hsl(var(--accent))',
          foreground: 'hsl(var(--accent-foreground))',
        },
        sidebar: {
          DEFAULT: 'hsl(var(--sidebar))',
          foreground: 'hsl(var(--sidebar-foreground))',
        },
        danger: {
          200: '#f1d5d8',
          500: '#ff4d4f',
        },
        background: '#f8f8fa',
      },
      padding: {
        navbar: 'var(--navbar-height)',
      },
      width: {
        50: '200px',
      },
    },
  },
  plugins: [
  ],
}


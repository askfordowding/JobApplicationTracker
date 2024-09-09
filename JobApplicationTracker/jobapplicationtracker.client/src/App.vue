<template>
    <div id="app">
        <nav>
            <router-link to="/">Dashboard</router-link>
            <router-link to="/add-application">Add New Application</router-link>
        </nav>
        <main>
            <router-view /> <!-- This is where routed components will be displayed -->
        </main>
    </div>
</template>

<script>
    export default {
        name: 'App',
    };
</script>

<style scoped>
    #app {
        margin: 0;
        padding: 0;
        font-family: Arial, sans-serif;
    }

    nav {
        background-color: #3498db; /* Navbar background */
        padding: 1rem;
        position: fixed;
        top: 0;
        width: 100%;
        display: flex;
        justify-content: center;
        z-index: 1000; /* Keep the navbar above other content */
    }

        nav a {
            color: white;
            margin: 0 1rem;
            text-decoration: none;
            font-weight: bold;
            font-size: 18px;
            cursor: pointer;
        }

            nav a:hover {
                text-decoration: underline;
            }

    main {
        padding-top: 4rem; /* Push content below the fixed navbar */
    }
</style>

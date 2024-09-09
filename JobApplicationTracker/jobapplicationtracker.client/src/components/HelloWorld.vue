<template>
    <div class="dashboard">
        <h1>Dashboard</h1>

        <!-- Overview Cards Section -->
        <section class="overview-cards">
            <div class="card">
                <h2>Total Applications</h2>
                <p>{{ totalApplications }}</p>
            </div>
            <div class="card">
                <h2>Applications in Progress</h2>
                <p>{{ applicationsInProgress }}</p>
            </div>
            <div class="card">
                <h2>Interviews Scheduled</h2>
                <p>{{ interviewsScheduled }}</p>
            </div>
            <div class="card">
                <h2>Offers Received</h2>
                <p>{{ offersReceived }}</p>
            </div>
        </section>

        <!-- Recent Applications Section -->
        <section class="recent-applications">
            <h2>Recent Applications</h2>
            <ul>
                <li v-for="(application, index) in recentApplications" :key="index">
                    <span>{{ application.company }}</span> - <span>{{ application.position }}</span>
                    <small>{{ new Date(application.dateOfApplication).toLocaleDateString() }}</small>
                    <!-- Delete Button -->
                    <button @click="deleteApplication(application.id)" class="delete-btn">Delete</button>
                </li>
            </ul>
        </section>

        <!-- Paging Controls -->
        <section class="pagination">
            <button @click="prevPage" :disabled="page === 1">Previous</button>
            <span>Page {{ page }}</span>
            <button @click="nextPage" :disabled="recentApplications.length < pageSize">Next</button>
        </section>

        <!-- Action Buttons -->
        <section class="actions">
            <router-link to="/add-application">
                <button class="add-application-btn">Add New Application</button>
            </router-link>
        </section>
    </div>
</template>

<script>
    import apiClient from '@/services/api';

    export default {
        name: 'Home',
        data() {
            return {
                recentApplications: [],
                totalApplications: 0,
                applicationsInProgress: 0,
                interviewsScheduled: 0,
                offersReceived: 0,
                page: 1,
                pageSize: 5, // Number of items per page
            };
        },
        mounted() {
            this.fetchDashboardData();
        },
        methods: {
            async fetchDashboardData() {
                try {
                    const response = await apiClient.getAllJobApplications(this.page, this.pageSize);
                    const applications = response.data;

                    this.totalApplications = applications.length;
                    this.applicationsInProgress = applications.filter(app => app.status === 'In Progress').length;
                    this.interviewsScheduled = applications.filter(app => app.interviewDate).length;
                    this.offersReceived = applications.filter(app => app.status === 'Offer Received').length;

                    this.recentApplications = applications;
                } catch (error) {
                    console.error('Error fetching job applications:', error);
                }
            },

            async deleteApplication(id) {
                try {
                    await apiClient.deleteJobApplication(id);
                    this.fetchDashboardData(); // Refresh the data after deletion
                } catch (error) {
                    console.error('Error deleting job application:', error);
                }
            },

            // Paging methods
            nextPage() {
                this.page++;
                this.fetchDashboardData();
            },
            prevPage() {
                if (this.page > 1) {
                    this.page--;
                    this.fetchDashboardData();
                }
            }
        },
    };
</script>

<style scoped>
    /* Styling for the dashboard remains the same as before */

    .pagination {
        display: flex;
        justify-content: center;
        margin-top: 2rem;
    }

        .pagination button {
            background-color: #3498db;
            color: white;
            border: none;
            padding: 0.5rem 1rem;
            margin: 0 0.5rem;
            cursor: pointer;
        }

            .pagination button:disabled {
                background-color: #cccccc;
                cursor: not-allowed;
            }
</style>

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
            };
        },
        mounted() {
            this.fetchDashboardData();
        },
        methods: {
            async fetchDashboardData() {
                try {
                    const response = await apiClient.getAllJobApplications();
                    const applications = response.data;

                    this.totalApplications = applications.length;
                    this.applicationsInProgress = applications.filter(app => app.status === 'In Progress').length;
                    this.interviewsScheduled = applications.filter(app => app.interviewDate).length;
                    this.offersReceived = applications.filter(app => app.status === 'Offer Received').length;

                    this.recentApplications = applications.slice(0, 5);
                } catch (error) {
                    console.error('Error fetching job applications:', error);
                }
            },

            // Delete a specific job application
            async deleteApplication(id) {
                try {
                    await apiClient.deleteJobApplication(id);
                    // Refetch the dashboard data after deletion
                    this.fetchDashboardData();
                } catch (error) {
                    console.error('Error deleting job application:', error);
                }
            },
        },
    };
</script>

<style scoped>
    .dashboard {
        padding: 2rem;
        font-family: Arial, sans-serif;
    }

    h1 {
        text-align: center;
        margin-bottom: 2rem;
    }

    .overview-cards {
        display: flex;
        justify-content: space-around;
        margin-bottom: 2rem;
    }

    .card {
        background-color: #f0f0f0;
        border-radius: 8px;
        padding: 1rem;
        width: 20%;
        text-align: center;
    }

        .card h2 {
            margin: 0;
            font-size: 18px;
        }

        .card p {
            font-size: 24px;
            font-weight: bold;
        }

    .recent-applications {
        margin-bottom: 2rem;
    }

        .recent-applications ul {
            list-style-type: none;
            padding: 0;
        }

        .recent-applications li {
            background-color: #f9f9f9;
            margin-bottom: 1rem;
            padding: 0.5rem;
            border-radius: 5px;
            display: flex;
            justify-content: space-between;
        }

    .actions {
        text-align: center;
    }

    .add-application-btn {
        background-color: #3498db;
        color: white;
        border: none;
        padding: 1rem 2rem;
        border-radius: 5px;
        cursor: pointer;
        font-size: 16px;
    }

        .add-application-btn:hover {
            background-color: #2980b9;
        }

    .delete-btn {
        background-color: #e74c3c;
        color: white;
        border: none;
        padding: 0.5rem 1rem;
        border-radius: 5px;
        cursor: pointer;
    }

        .delete-btn:hover {
            background-color: #c0392b;
        }
</style>

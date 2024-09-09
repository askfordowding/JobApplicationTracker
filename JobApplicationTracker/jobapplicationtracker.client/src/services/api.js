
import axios from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:7101/api',  // Adjust this base URL as per your backend API
    headers: {
        'Content-Type': 'application/json',
    },
});

export default {
    async createJobApplication(application) {
        return apiClient.post('/jobapplications', application);
    },
    async getAllJobApplications() {
        return apiClient.get('/jobapplications');
    },
    async getAllJobApplications(page = 1, pageSize = 10) {
        return apiClient.get('/jobapplications', {
            params: {
                page,
                pageSize,
            },
        });
    },
    async updateJobApplication(id, application) {
        return apiClient.put(`/jobapplications/${id}`, application);
    },
    async deleteJobApplication(id) {
        return apiClient.delete(`/jobapplications/${id}`);
    },
};


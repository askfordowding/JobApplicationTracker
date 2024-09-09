<!-- src/components/AddApplication.vue -->
<template>
    <div class="add-application">
        <header class="header">
            <h1>Add a New Job Application</h1>
        </header>
        <section class="section">
            <form @submit.prevent="submitApplication">
                <div class="input-group">
                    <label for="company">Company</label>
                    <input v-model="application.company" id="company" placeholder="Company" required />
                </div>
                <div class="input-group">
                    <label for="position">Position</label>
                    <input v-model="application.position" id="position" placeholder="Position" required />
                </div>
                <!-- Date of Application -->
                <div class="input-group">
                    <label for="dateOfApplication">Date of Application</label>
                    <input type="date" v-model="application.dateOfApplication" id="dateOfApplication" required />
                </div>
                <!-- Interview Date -->
                <div class="input-group">
                    <label for="interviewDate">Interview Date</label>
                    <input type="date" v-model="application.interviewDate" id="interviewDate" />
                </div>

                <div class="input-group">
                    <label for="status">Status</label>
                    <select v-model="application.status" id="status" required>
                        <option value="Pending">Pending</option>
                        <option value="Interview Scheduled">Interview Scheduled</option>
                        <option value="Offered">Offered</option>
                        <option value="Rejected">Rejected</option>
                    </select>
                    <div class="input-group">
                        <label for="mainContact">Main Contact</label>
                        <input v-model="application.mainContact" id="mainContact" placeholder="Main Contact" />
                    </div>

                </div>
                <div class="input-group">
                    <label for="notes">Notes</label>
                    <textarea v-model="application.notes" id="notes" placeholder="Additional notes"></textarea>
                </div>
                <button type="submit" class="btn-primary">Submit Application</button>
            </form>
        </section>
    </div>
</template>

<script>
    import api from '../services/api';

    export default {
        name: 'AddApplication',
        data() {
            return {
                application: {
                    company: '',
                    position: '',
                    coverLetter: '',
                    cvPath: '',
                    dateOfApplication: '',  // Ensure this field is required
                    interviewDate: null,
                    mainContact: '',
                    notes: '',
                    status: 'Pending',
                },
            };
        },
        methods: {
            async submitApplication() {
                try {
                    // Ensure that DateOfApplication is set, use today's date if it's not filled
                    if (!this.application.dateOfApplication) {
                        this.application.dateOfApplication = new Date().toISOString().slice(0, 10); // format as yyyy-mm-dd
                    }

                    // Post the data
                    await api.createJobApplication(this.application);

                    // Redirect to homepage after successful submission
                    this.$router.push('/');
                } catch (error) {
                    console.error("There was an error submitting the application:", error);
                    alert("Failed to submit the application. Please try again.");
                }
            },
        },
    };
</script>

<style lang="scss">
    @import '@/styles/colors.scss';
    @import '@/styles/typography.scss';
    @import '@/styles/layout.scss';
    @import '@/styles/buttons.scss';
    @import '@/styles/forms.scss';

    .add-application {
        .header {
            text-align: center;
            margin-bottom: 2rem;

            h1 {
                color: $primary-color;
            }
        }

        .section {
            max-width: 600px;
            margin: 0 auto;
            background-color: #fff;
            padding: 2rem;
            border-radius: 0.5rem;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        }
    }
</style>

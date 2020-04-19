export const config = {
    apiUrl: 'http://localhost:5000/api',
    endpoint: {
        user: 'user',
        country: 'countries',
        login: 'user/login',
        uploadProfileImage: (id: string) => `user/${id}/upload-photo`,
        post: 'posts',
    }
};
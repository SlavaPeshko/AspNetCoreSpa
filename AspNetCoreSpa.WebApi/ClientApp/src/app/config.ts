export const config = {
    apiUrl: 'http://localhost:5000/api',
    endpoint: {
        posts: {
            route: 'posts',
            get: (page: number, items: number) => `posts/${page}/${items}`,
        },
        user: {
            route: 'user',
            login: 'user/login',
            uploadProfileImage: (id: string) => `user/${id}/upload-photo`,
        },
        countries: {
            route: 'countries',
        },
    }
};
export const config = {
    apiUrl: 'http://localhost:5000/api',
    endpoint: {
        posts: {
            route: 'posts',
            get: (page: number, items: number) => `posts/${page}/${items}`,
            createLike: (postId: number) => `posts/${postId}/like`,
            deleteLike: (postId: number, likeId: number) => `posts/${postId}/like/${likeId}`
        },
        user: {
            route: 'user',
            login: 'user/login',
            uploadProfileImage: (id: number) => `user/${id}/upload-photo`,
            changeEmail: (id: number) => `user/${id}/email`,
        },
        countries: {
            route: 'countries',
        },
        tokens: {
            refreshToken: 'token'
        }
    }
};
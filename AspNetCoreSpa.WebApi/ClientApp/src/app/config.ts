export const config = {
  apiUrl: "http://localhost:5000/api",
  endpoint: {
    posts: {
      route: "posts",
      get: (page: number, items: number) => `posts/${page}/${items}`,
      getRating: (postId: number) => `posts/${postId}/like`,
    },
    user: {
      create: "user", // post
      update: "user", // put
      get: (id: number) => `user/${id}`,
      login: "user/login",
      uploadProfileImage: "user/upload-image", // post
      getPhotoUser: "user/photo", // get
      changeEmail: (id: number) => `user/${id}/email`,
      sendEmail: (email: string) => `user/${email}/forgot-password`, // get
      validateToken: (token: string) => `user/${token}/validate`, // get
      forgotPassword: `user/forgot-password`, // post
    },
    countries: {
      route: "countries",
    },
    tokens: {
      refreshToken: "token",
    },
    likes: {
      delete: (id: number) => `likes/${id}`,
      create: `likes`,
    },
    sms: {
      route: "sms",
      sendSms: "sms",
    },
  },
};

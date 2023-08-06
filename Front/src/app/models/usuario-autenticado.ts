export class UsuarioAutenticado {
    constructor(
        public authenticated: boolean,
        public created: string,
        public expiration: string,
        public accessToken: string,
        public refreshToken: string,
        public message: string){ }
}

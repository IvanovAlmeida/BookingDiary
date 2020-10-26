export class LocalStorageUtils {
    private _prefix: string = "ege_";

    public obterUsuario() {
        return JSON.parse(localStorage.getItem(`${this._prefix}.user`));
    }

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.accessToken);
        this.salvarUsuario(response.userToken);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem(`${this._prefix}.token`);
        localStorage.removeItem(`${this._prefix}.user`);
    }

    public obterTokenUsuario(): string {
        return localStorage.getItem(`${this._prefix}.token`);
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem(`${this._prefix}.token`, token);
    }

    public salvarUsuario(user: string) {
        localStorage.setItem(`${this._prefix}.user`, JSON.stringify(user));
    }
}
import { HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { throwError } from "rxjs";

import { LocalStorageUtils } from "../utils/localstorage";
import { QueryStringUtils } from "../utils/query-string-utils";

export abstract class BaseService {

    public LocalStorage = new LocalStorageUtils();
    protected QueryString = new QueryStringUtils();
    protected UrlServiceV1: string = environment.apiUrlv1;

    protected ObterHeaderJson() {
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
    }

    protected ObterAuthHeaderJson() {
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.LocalStorage.obterTokenUsuario()}`
            })
        }
    }

    protected extractData(response: any) {
        return response.data || {};
    }

    protected serviceError(response: Response | any) {
        let customError: string[] = [];
        let customResponse = { error: { errors: [] } }

        if(response instanceof HttpErrorResponse) {
            if(response.statusText === 'Unknown Error') {
                customError.push("Ocorreu um erro desconhecido");
                response.error.errors = customError;
            }
        }

        if (response.status === 500) {
            customError.push("Ocorreu um erro no processamento, tente novamente mais tarde ou contate o nosso suporte.");
            
            // Erros do tipo 500 não possuem uma lista de erros
            // A lista de erros do HttpErrorResponse é readonly                
            customResponse.error.errors = customError;
            return throwError(customResponse);
        }

        return throwError(response);
    }
}
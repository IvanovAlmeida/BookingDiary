import { stringify, parse, parseUrl, ParseOptions } from "query-string";

export class QueryStringUtils {

    private parseOptions : ParseOptions = {
        parseBooleans: true, 
        parseNumbers: true
    };

    /**
     * Parse object to QueryString
     * @param any obj
     * @returns string
     */
    public stringfy(obj: any) : string {
        return stringify(obj, this.parseOptions);
    }

    /**
     * Parse QueryString to object
     * @param query string
     * @returns object
     */
    public parse(query: string) : object {
        return parse(query, this.parseOptions);
    }

    /**
     * Parse url to object
     * @param url string
     * @returns object
     */
    public parseUrl(url: string) : object {
        return parseUrl(url);
    }
}
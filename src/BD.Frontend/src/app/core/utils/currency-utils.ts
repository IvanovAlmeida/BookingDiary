export class CurrencyUtils {

    public static StringParaDecimal(input): any {
        if (input === null) return 0;

        input = input.replace(/[R$]/g, '');
        input = input.replace(/\./g, '');
        input = input.replace(/,/g, '.');

        let ret = parseFloat(input);

        return isNaN(ret) ? null : ret;
    }

    public static DecimalParaString(input): any {
        var ret = (input) ? input.toString().replace(".", ",") : null;
        if (ret) {
            var decArr = ret.split(",");
            if (decArr.length > 1) {
                var dec = decArr[1].length;
                if (dec === 1) { ret += "0"; }
            }
        }
        return ret;
    }
}
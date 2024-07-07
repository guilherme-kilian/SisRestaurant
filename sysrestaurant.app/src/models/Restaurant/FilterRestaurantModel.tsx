export class FilterRestaurantModel {
    name: string | null
    category: string | null
    open: boolean | null
    take: number
    skip: number

    constructor (name: string | null, category: string | null, open: boolean | null){
        this.name = name;
        this.category = category;
        this.open = open;
        this.skip = 0;
        this.take = 1000;
    }

    getQueryString() : string{

        if(!this.name && !this.category && !this.open){
            return "";
        }

        let queryString = "?";
        
        if(this.name){
            queryString = this.addQueryParam(queryString, `name=${this.name}`)
        }
        if(this.category){
            queryString = this.addQueryParam(queryString, `category=${this.category}`)
        }
        if(this.open){
            queryString = this.addQueryParam(queryString, `open=${this.open}`)
        }

        queryString = this.addQueryParam(queryString, `take=${this.take}`)
        queryString = this.addQueryParam(queryString, `skip=${this.skip}`)
        
        return queryString;
    }

    addQueryParam(query: string, val: string){
        if(query === '?'){
            query += val;
        }
        else{
            query += `&${val}`;
        }

        return query;
    }
}
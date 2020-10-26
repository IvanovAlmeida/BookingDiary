import { Claim } from './claim';

export class Role {
    id: number;
    name: string;
    description: string;
    disabledAt: Date;
    enabled: boolean;
    claims: Claim[];
}
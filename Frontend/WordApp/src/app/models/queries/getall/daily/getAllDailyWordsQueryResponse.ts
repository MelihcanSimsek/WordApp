import { SynonmResponseDto } from "./synonmResponseDto";

export interface GetAllDailyWordsQueryResponse{
    id:string;
    foreignWord: string;
    translatedWord: string;
    synonms: SynonmResponseDto[];
}
import { SynonmResponseDto } from "./synonmResponseDto";

export interface GetAllKnownWordsQueryResponse{
    id:string;
    foreignWord: string;
    translatedWord: string;
    synonms: SynonmResponseDto[];
}
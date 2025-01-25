import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"

class KeepsService {
   async getKeepById(keepId) {
        const response = await api.get(`api/keeps/${keepId}`)
        logger.log('got keep by Id', response.data)
        AppState.activeKeep = response.data
    }

   async IncrementKeeps(keepId, viewData) {
        const response = await api.put(`api/keeps/${keepId}`, viewData)
        AppState.activeKeep.views = response
    }


    setActiveKeep(keep) {
        AppState.activeKeep = keep
        
    }


    async getAllKeeps() {
        const response = await api.get('api/keeps')
        logger.log('got all keeps', response.data)
        AppState.keeps = response.data.map(pojo => new Keep(pojo))
    }

}



export const keepsService = new KeepsService()
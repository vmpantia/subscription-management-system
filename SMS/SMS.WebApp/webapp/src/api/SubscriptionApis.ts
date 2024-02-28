import { SubscriptionViewModel } from "@/interfaces/viewmodels/subscription/SubscriptionViewModel";
import { AxiosApi } from "./AxiosApi";
import { Result } from "@/interfaces/common/Result";

export const getSubscriptions = () => 
    AxiosApi.get<Result<SubscriptionViewModel[]>>('subscriptions')
            .then(({data}) => data);
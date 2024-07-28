// generated with @7nohe/openapi-react-query-codegen@1.4.1 

import { UseQueryOptions, useSuspenseQuery } from "@tanstack/react-query";
import { CubeService } from "../requests/services.gen";
import * as Common from "./common";
export const useCubeServiceGetApiV1CubeByUserIdSuspense = <TData = Common.CubeServiceGetApiV1CubeByUserIdDefaultResponse, TError = unknown, TQueryKey extends Array<unknown> = unknown[]>({ userId }: {
  userId: number;
}, queryKey?: TQueryKey, options?: Omit<UseQueryOptions<TData, TError>, "queryKey" | "queryFn">) => useSuspenseQuery<TData, TError>({ queryKey: Common.UseCubeServiceGetApiV1CubeByUserIdKeyFn({ userId }, queryKey), queryFn: () => CubeService.getApiV1CubeByUserId({ userId }) as TData, ...options });

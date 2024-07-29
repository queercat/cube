// generated with @7nohe/openapi-react-query-codegen@1.4.1 

import { UseMutationOptions, UseQueryOptions, useMutation, useQuery } from "@tanstack/react-query";
import { AuthService, CubeService } from "../requests/services.gen";
import { LoginRequest } from "../requests/types.gen";
import * as Common from "./common";
export const useAuthServiceGetApiV1AuthNonce = <TData = Common.AuthServiceGetApiV1AuthNonceDefaultResponse, TError = unknown, TQueryKey extends Array<unknown> = unknown[]>(queryKey?: TQueryKey, options?: Omit<UseQueryOptions<TData, TError>, "queryKey" | "queryFn">) => useQuery<TData, TError>({ queryKey: Common.UseAuthServiceGetApiV1AuthNonceKeyFn(queryKey), queryFn: () => AuthService.getApiV1AuthNonce() as TData, ...options });
export const useCubeServiceGetApiV1CubeByUserId = <TData = Common.CubeServiceGetApiV1CubeByUserIdDefaultResponse, TError = unknown, TQueryKey extends Array<unknown> = unknown[]>({ userId }: {
  userId: string;
}, queryKey?: TQueryKey, options?: Omit<UseQueryOptions<TData, TError>, "queryKey" | "queryFn">) => useQuery<TData, TError>({ queryKey: Common.UseCubeServiceGetApiV1CubeByUserIdKeyFn({ userId }, queryKey), queryFn: () => CubeService.getApiV1CubeByUserId({ userId }) as TData, ...options });
export const useAuthServicePostApiV1AuthLogin = <TData = Common.AuthServicePostApiV1AuthLoginMutationResult, TError = unknown, TContext = unknown>(options?: Omit<UseMutationOptions<TData, TError, {
  requestBody?: LoginRequest;
}, TContext>, "mutationFn">) => useMutation<TData, TError, {
  requestBody?: LoginRequest;
}, TContext>({ mutationFn: ({ requestBody }) => AuthService.postApiV1AuthLogin({ requestBody }) as unknown as Promise<TData>, ...options });

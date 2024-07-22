// generated with @7nohe/openapi-react-query-codegen@1.4.1 

import { UseQueryResult } from "@tanstack/react-query";
import { CubeService } from "../requests/services.gen";
export type CubeServiceGetApiV1CubeByUserIdDefaultResponse = Awaited<ReturnType<typeof CubeService.getApiV1CubeByUserId>>;
export type CubeServiceGetApiV1CubeByUserIdQueryResult<TData = CubeServiceGetApiV1CubeByUserIdDefaultResponse, TError = unknown> = UseQueryResult<TData, TError>;
export const useCubeServiceGetApiV1CubeByUserIdKey = "CubeServiceGetApiV1CubeByUserId";
export const UseCubeServiceGetApiV1CubeByUserIdKeyFn = ({ userId }: {
  userId: number;
}, queryKey?: Array<unknown>) => [useCubeServiceGetApiV1CubeByUserIdKey, ...(queryKey ?? [{ userId }])];

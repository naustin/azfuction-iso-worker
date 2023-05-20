
// install minio for storage
helm repo add minio https://operator.min.io/
helm install --namespace minio-operator --create-namespace --generate-name minio/minio-operator

// create minio tenant, this default yaml creates 4 nodes
kubectl apply -f https://raw.githubusercontent.com/minio/operator/master/examples/kustomization/tenant-lite/tenant.yaml

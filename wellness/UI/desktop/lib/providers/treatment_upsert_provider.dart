import '../models/treatment_upsert.dart';
import 'base_provider.dart';

class TreatmentUpsertProvider extends BaseProvider<TreatmentUpsert> {
  TreatmentUpsertProvider() : super("Treatment");

  @override
  TreatmentUpsert fromJson(data) {
    return TreatmentUpsert.fromJson(data);
  }
}
